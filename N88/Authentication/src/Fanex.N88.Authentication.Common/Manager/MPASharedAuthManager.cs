using Fanex.N88.Authentication.Common.Core;
using Fanex.N88.Authentication.Common.Models;
using Fanex.N88.Authentication.Common.Services;
using System;

namespace Fanex.N88.Authentication.Common
{
    public class MPASharedAuthManager
    {
        private static MPASharedSessionOption AuthOptions;
        private static readonly Lazy<IMPAAuthStrategy> LazyStrategy = new Lazy<IMPAAuthStrategy>(() => new MPAAuthSharedSessionStrategy(AuthOptions, RedisClient));
        private static readonly Lazy<IRedisClient> LazyRedisClient = new Lazy<IRedisClient>(() => new AuthRedisClient(AuthOptions.Redis, new BinarySerializer()));
        private static IRedisClient RedisClient => LazyRedisClient.Value;

        public static MPASharedAuthManager UseOptions(MPASharedSessionOption authOptions = null)
        {
            AuthOptions = authOptions ?? new MPASharedSessionOption();
            return new MPASharedAuthManager();
        }

        public MPASharedAuthManager UseRedis(string host, int port, string password, int database, int keepAlive = 180)
        {
            _ = AuthOptions ?? throw new NullReferenceException($"{nameof(AuthOptions)} has not been initialized");
            AuthOptions.Redis = new AuthRedisOption
            {
                Host = host,
                Port = port,
                Password = password,
                Database = database,
                KeepAlive = keepAlive
            };
            return this;
        }

        public MPASharedAuthManager UsePrefixKey(string prefixKey)
        {
            _ = AuthOptions ?? throw new NullReferenceException($"{nameof(AuthOptions)} has not been initialized");
            AuthOptions.PrefixKey = prefixKey;
            return this;
        }

        public static IMPAAuthStrategy MPAAuthStrategy => LazyStrategy.Value;

        public static readonly IMPAPrincipalGenerater MPAPrincipalGenerater = new MPAPrincipalGenerater();
    }
}