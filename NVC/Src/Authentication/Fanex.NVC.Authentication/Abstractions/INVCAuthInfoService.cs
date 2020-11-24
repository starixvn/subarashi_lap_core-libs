using Fanex.Core.Authentication;
using Fanex.NVC.Authentication.Infrastructure;
using System.Collections.Generic;

namespace Fanex.NVC.Authentication
{
    public interface INVCAuthInfoService : IAuthInfoService
    {
        IEnumerable<NVCFunctionAuthInfo> FunctionList { get; }
        IEnumerable<Brand> BrandList { get; }
        bool IsLicenseeUser { get; }
    }
}