namespace Fanex.N88.Authentication.Common.Models
{
    public class AuthRedisOption
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public int Database { get; set; }
        public int KeepAlive { get; set; }
    }
}