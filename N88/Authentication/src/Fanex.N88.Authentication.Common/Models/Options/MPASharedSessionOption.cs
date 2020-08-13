namespace Fanex.N88.Authentication.Common.Models
{
    public class MPASharedSessionOption
    {
        public string PrefixKey { get; set; }
        public AuthRedisOption Redis { get; set; }
    }
}