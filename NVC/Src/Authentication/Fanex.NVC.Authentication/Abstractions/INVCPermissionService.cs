using Fanex.NVC.Authentication.Infrastructure;

namespace Fanex.NVC.Authentication
{
    public interface INVCPermissionService
    {
        bool HasPermission(string functionKey, PermissionPolicy policy = PermissionPolicy.Read);
    }
}