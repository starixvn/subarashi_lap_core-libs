using System;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    [Serializable]
    public class SummarySportList
    {
        public int key { get; set; }

        public string name { get; set; }

        public decimal sum { get; set; }
    }
}
