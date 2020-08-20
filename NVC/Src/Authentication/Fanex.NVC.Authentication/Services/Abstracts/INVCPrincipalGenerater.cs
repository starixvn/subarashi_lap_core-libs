using Fanex.Core.Authentication;
using Fanex.Core.Authentication.Abstractions;
using Fanex.NVC.Authentication.Models;

namespace Fanex.NVC.Authentication.Services
{
    public interface INVCPrincipalGenerater : IPrincipalGenerater<NVCAuthInfo>
    {
    }
}