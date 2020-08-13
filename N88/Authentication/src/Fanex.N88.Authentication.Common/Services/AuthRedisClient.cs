using Fanex.N88.Authentication.Common.Core;
using Fanex.N88.Authentication.Common.Models;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fanex.N88.Authentication.Common.Services
{
    public class AuthRedisClient : IRedisClient
    {
        private readonly AuthRedisOption _options;
        private readonly ISerializer _serializer;

        public string Host => _options.Host;
        public int Port => _options.Port;
        public string Password => _options.Password;
        public int Database => _options.Database;
        public int KeepAlive => _options.KeepAlive;

        public AsyncLazy<ConnectionMultiplexer> Multiplexer { get; private set; }
        public AsyncLazy<IDatabase> DBConnection { get; private set; }

        public AuthRedisClient(AuthRedisOption options, ISerializer serializer)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            InitLazy();
        }

        private void InitLazy()
        {
            Multiplexer = new AsyncLazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.ConnectAsync(new ConfigurationOptions
            {
                KeepAlive = KeepAlive,
                EndPoints =
                    {
                        { Host, Port }
                    },
                Password = Password,
                DefaultDatabase = Database,
            }));

            DBConnection = new AsyncLazy<IDatabase>(async () =>
            {
                var connection = await Multiplexer.Value;
                return connection.GetDatabase(Database);
            });
        }

        public async Task<T> GetFromAssembliesAsync<T>(string key)
        {
            var dbConnection = await DBConnection.Value;
            var hashEntries = await dbConnection.HashGetAllAsync(key);
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