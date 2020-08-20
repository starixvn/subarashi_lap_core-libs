namespace Fanex.Core.Authentication.Models
{
    public class AuthSharedSessionOption
    {
        public string PrefixKey { get; set; }
        public AuthRedisOption Redis { get; set; }
    }
}