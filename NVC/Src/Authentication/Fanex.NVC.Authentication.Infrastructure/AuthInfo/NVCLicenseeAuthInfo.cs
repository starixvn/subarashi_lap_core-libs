using System;
using System.Collections.Generic;

namespace Fanex.NVC.Authentication.Infrastructure
{
    [Serializable]
    public class NVCLicenseeAuthInfo
    {
        public int LicenseeId { get; set; }

        public string LicenseeName { get; set; }

        public bool IsAllowedCustomerComm { get; set; }

        public bool IsEnableBA { get; set; }

        public IEnumerable<string> OfferedSubProductList { get; set; }
    }
}