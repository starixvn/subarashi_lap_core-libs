using System;
using System.Collections.Generic;

namespace Fanex.NVC.Authentication.Infrastructure
{
    [Serializable]
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FunctionKey { get; set; }
        public IDictionary<int, string> TpCurrencyList { get; set; }
        public IDictionary<int, string> CurrencyList { get; set; }
        public IDictionary<int, int[]> CurrencyAgentList { get; set; }
    }
}