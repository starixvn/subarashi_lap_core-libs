using Microsoft.Extensions.Options;

namespace Fanex.NVC.Authentication.Extensions.Models
{
    public class PostConfigureNVCAuthenticationOptions : IPostConfigureOptions<NVCAuthenticationOptions>
    {
        public void PostConfigure(string name, NVCAuthenticationOptions options)
        {
            options.Validate();
        }
    }
}