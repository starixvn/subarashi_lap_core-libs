namespace Fanex.NVC.Authentication.Services
{
    public interface INVCPermissionService
    {
        bool HasPermission(string functionKey, PermissionPolicy policy = PermissionPolicy.Read);
    }
}