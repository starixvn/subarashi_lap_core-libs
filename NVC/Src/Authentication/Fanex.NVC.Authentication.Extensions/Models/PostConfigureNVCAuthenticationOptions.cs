using Microsoft.Extensions.Options;

namespace Fanex.NVC.Authentication.Extensions
{
    public class PostConfigureNVCAuthenticationOptions : IPostConfigureOptions<NVCAuthenticationOptions>
    {
        public void PostConfigure(string name, NVCAuthenticationOptions options)
        {
            options.Validate();
        }
    }
}