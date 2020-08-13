using System;

namespace Fanex.N88.Authentication.Common.Models
{
    [Serializable]
    public class LicenseeAuthInfo
    {
        public int LicenseeId { get; set; }

        public string LicenseeName { get; set; }

        public bool IsAllowedCustomerComm { get; set; }

        public bool IsEnableBA { get; set; }
    }
}