namespace Fanex.Core.Authentication.Abstractions
{
    public interface ILicenseeAuthInfo
    {
        int LicenseeId { get; set; }

        string LicenseeName { get; set; }

        bool IsAllowedCustomerComm { get; set; }

        bool IsEnableBA { get; set; }
    }
}