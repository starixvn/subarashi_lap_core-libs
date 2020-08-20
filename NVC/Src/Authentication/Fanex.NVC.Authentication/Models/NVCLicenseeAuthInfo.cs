using Fanex.Core.Authentication.Abstractions;
using System;

namespace Fanex.NVC.Authentication.Models
{
    [Serializable]
    public class NVCLicenseeAuthInfo : ILicenseeAuthInfo
    {
        public int LicenseeId { get; set; }

        public string LicenseeName { get; set; }

        public bool IsAllowedCustomerComm { get; set; }

        public bool IsEnableBA { get; set; }
    }
}