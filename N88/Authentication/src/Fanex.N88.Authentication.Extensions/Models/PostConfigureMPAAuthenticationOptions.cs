using Microsoft.Extensions.Options;

namespace Fanex.N88.Authentication.Extensions.Models
{
    public class PostConfigureMPAAuthenticationOptions : IPostConfigureOptions<MPAAuthenticationOptions>
    {
        public void PostConfigure(string name, MPAAuthenticationOptions options)
        {
            options.Validate();
        }
    }
}