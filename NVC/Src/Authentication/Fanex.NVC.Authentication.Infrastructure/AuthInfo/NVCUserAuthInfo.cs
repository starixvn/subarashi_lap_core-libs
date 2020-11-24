using System;
using System.Collections.Generic;

namespace Fanex.NVC.Authentication.Infrastructure
{
    [Serializable]
    public class NVCUserAuthInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Language { get; set; }
        public int OnUserId { get; set; }
        public IEnumerable<NVCFunctionAuthInfo> FunctionList { get; set; }
        public IDictionary<int, string> CurrencyList { get; set; }
        public IDictionary<int, int[]> CurrencyAgentList { get; set; }
        public bool SupportMultiBrand { get; set; }
        public IEnumerable<Brand> BrandList { get; set; }
        public string DefaultBaseCurrency { get; set; }
        public string DefaultReportUrl { get; set; }
        public bool IsLicenseeUser { get; set; }
    }
}