using Fanex.Core.Authentication.Abstractions;
using Fanex.Core.Authentication.Models;
using Fanex.Core.Utils;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fanex.Core.Authentication.Services
{
    public class RedisSessionClient : ISessionClient
    {
        private readonly AuthRedisOption _options;
        private readonly ISerializer _serializer;

        public string Host => _options.Host;
        public int Port => _options.Port;
        public string Password => _options.Password;
        public int Database => _options.Database;

        public AsyncLazy<IDatabase> DBConnectionAsync { get; private set; }

        public Lazy<IDatabase> DBConnection { get; private set; }

        public RedisSessionClient(AuthRedisOption options, ISerializer serializer)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            InitLazy();
        }

        private void InitLazy()
        {
            DBConnectionAsync = new AsyncLazy<IDatabase>(async () =>
            {
                var connection = await ConnectionMultiplexer.ConnectAsync(new ConfigurationOptions
                {
                    EndPoints =
                    {
                        { Host, Port }
                    },
                    Password = Password,
                    DefaultDatabase = Database,
                });

                return connection.GetDatabase(Database);
            });

            DBConnection = new Lazy<IDatabase>(() =>
            {
                var connection = ConnectionMultiplexer.Connect(new ConfigurationOptions
                {
                    EndPoints =
                    {
                        { Host, Port }
                    },
                    Password = Password,
                    DefaultDatabase = Database,
                });

                return connection.GetDatabase(Database);
            });
        }

        public T Get<T>(string key)
        {
            var dbConnection = DBConnection.Value;
            var hashEntries = dbConnection.HashGetAll(key);
            var model = MapFromHash<T>(hashEntries);
            return model;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var dbConnection = await DBConnectionAsync.Value.ConfigureAwait(false);
            var hashEntries = await dbConnection.HashGetAllAsync(key).ConfigureAwait(false);
            var model = MapFromHash<T>(hashEntries);
            return model;
        }

        private T MapFromHash<T>(HashEntry[] hashEntries)
        {
            if (!hashEntries.Any())
            {
                return default(T);
            }

            var result = (T)Activator.CreateInstance(typeof(T));
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                var hashEntryMatch = hashEntries.FirstOrDefault(_ => _.Name.Equals(prop.Name));
                if (hashEntryMatch != default(HashEntry))
                {
                    var value = _serializer.Deserialize<dynamic>(hashEntryMatch.Value);
                    var type = prop.PropertyType;
                    prop.SetValue(result, Convert.ChangeType(value, type));
                }
            }
            return result;
        }
    }
}