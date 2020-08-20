using Fanex.Core.Authentication.Abstractions;
using System;
using System.Collections.Generic;

namespace Fanex.NVC.Authentication.Models
{
    [Serializable]
    public class NVCUserAuthInfo : IUserAuthInfo<NVCFunctionAuthInfo>
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Language { get; set; }

        public int OnUserId { get; set; }

        public IEnumerable<NVCFunctionAuthInfo> FunctionList { get; set; }

        public IDictionary<int, string> CurrencyList { get; set; }

        public IDictionary<int, int[]> CurrencyAgentList { get; set; }

        public string DefaultBaseCurrency { get; set; }
    }
}