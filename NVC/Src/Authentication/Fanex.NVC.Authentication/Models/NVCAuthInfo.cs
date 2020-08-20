using Fanex.Core.Authentication.Abstractions;

namespace Fanex.NVC.Authentication.Models
{
    public class NVCAuthInfo : IAuthInfo<NVCLicenseeAuthInfo, NVCUserAuthInfo>
    {
        public NVCLicenseeAuthInfo LicenseeAuthInfo { get; set; }
        public NVCUserAuthInfo UserAuthInfo { get; set; }
    }
}