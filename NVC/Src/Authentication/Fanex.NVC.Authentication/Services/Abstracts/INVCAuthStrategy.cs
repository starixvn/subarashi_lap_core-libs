using Fanex.Core.Authentication;
using Fanex.NVC.Authentication.Models;

namespace Fanex.NVC.Authentication.Services
{
    public interface INVCAuthStrategy : IAuthStrategy<NVCAuthInfo>
    {
    }
}