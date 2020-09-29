using Fanex.NVC.Authentication.Infrastructure;
using System;
using System.Linq;

namespace Fanex.NVC.Authentication
{
    public class NVCPermissionService : INVCPermissionService
    {
        private readonly INVCAuthInfoService _authInfoService;

        public NVCPermissionService(INVCAuthInfoService authInfoService)
        {
            _authInfoService = authInfoService;
        }

        public bool HasPermission(string functionKey, PermissionPolicy policy = PermissionPolicy.Read)
        {
            Func<NVCFunctionAuthInfo, bool> hasFunction = function => string.Equals(function.FunctionKey, functionKey, StringComparison.OrdinalIgnoreCase);
            Func<NVCFunctionAuthInfo, bool> hasPolicy = function => (byte)function.Policy >= (byte)policy;
            var result = _authInfoService.FunctionList.Any(function => hasFunction(function) && hasPolicy(function));
            return result;
        }
    }
}