using Fanex.Core.Authentication.Services;
using Fanex.NVC.Authentication.Models;
using System.Collections.Generic;

namespace Fanex.NVC.Authentication.Services
{
    public interface INVCAuthInfoService : IAuthInfoService
    {
        IEnumerable<NVCFunctionAuthInfo> FunctionList { get; }
    }
}