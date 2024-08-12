using Fanex.ThirdParty.ExchangeProduct.Enums;
using System;
using System.Collections.Generic;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    [Serializable]
    public class BetHistory
    {
        public CitiStatus status { get; set; }

        public decimal currentPage { get; set; }

        public decimal totalPage { get; set; }

        public BetHistory matched { get; set; }

        public BetHistory unmatched { get; set; }
    }
}
