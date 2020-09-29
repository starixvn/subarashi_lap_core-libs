using Fanex.NVC.Authentication.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Fanex.NVC.Authentication.Extensions
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class NVCAuthorizeAttribute : TypeFilterAttribute
    {
        public NVCAuthorizeAttribute(string functionKey, PermissionPolicy policy = PermissionPolicy.Read)
            : base(typeof(NVCAuthorizeImplAttribute))
        {
            Arguments = new[] { functionKey as object, policy as object };
        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public sealed class NVCAuthorizeImplAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private const string ErrorMsg = "403 Forbidden";

        private readonly INVCPermissionService _permissionService;

        private readonly string _functionKey;
        private readonly PermissionPolicy _policy;

        public NVCAuthorizeImplAttribute(INVCPermissionService permissionService,
            string functionKey,
            PermissionPolicy policy
            )
        {
            _permissionService = permissionService;
            _functionKey = functionKey;
            _policy = policy;
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var isAuthorized = context.HttpContext.User.Identity.IsAuthenticated && _permissionService.HasPermission(_functionKey, _policy);
            if (!isAuthorized)
            {
                context.Result = new JsonResult(new
                {
                    Msg = ErrorMsg,
                    IsSuccess = false
                })
                { StatusCode = (int)HttpStatusCode.Forbidden };
            }

            return Task.CompletedTask;
        }
    }
}