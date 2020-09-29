using Fanex.Core.Authentication;
using Fanex.NVC.Authentication.Infrastructure;
using System.Threading.Tasks;

namespace Fanex.NVC.Authentication
{
    public class NVCAuthSharedSessionStrategy : BaseAuthSharedSessionStrategy<AuthSharedSessionOption>, INVCAuthStrategy
    {
        public NVCAuthSharedSessionStrategy(AuthSharedSessionOption options, ISessionClient sessionClient)
            : base(options, sessionClient)
        {
        }

        public virtual NVCAuthInfo Authenticate(string token)
        {
            var key = BuildKey(token);
            var result = _sessionClient.Get<NVCAuthInfo>(key);
            return result;
        }

        public virtual async Task<NVCAuthInfo> AuthenticateAsync(string token)
        {
            var key = BuildKey(token);
            var result = await _sessionClient.GetAsync<NVCAuthInfo>(key).ConfigureAwait(false);
            return result;
        }
    }
}