namespace Fanex.Core.Authentication
{
    public class AuthSharedSessionOption
    {
        public string PrefixKey { get; set; }
        public AuthRedisOption Redis { get; set; }
    }
}