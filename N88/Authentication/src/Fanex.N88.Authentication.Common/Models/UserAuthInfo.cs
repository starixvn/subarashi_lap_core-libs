using System;
using System.Collections.Generic;

namespace Fanex.N88.Authentication.Common.Models
{
    [Serializable]
    public class UserAuthInfo
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Language { get; set; }

        public int OnUserId { get; set; }

        public bool IsInternal { get; set; }

        public List<FunctionAuthInfo> FunctionList { get; set; }

        public IDictionary<int, string> CurrencyList { get; set; }

        public IDictionary<int, int[]> CurrencyAgentList { get; set; }

        public string DefaultReportUrl { get; set; }

        public string DefaultBaseCurrency { get; set; }
    }
}