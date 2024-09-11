using Fanex.ThirdParty.ExchangeProduct.Enums;
using System;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    [Serializable]
    public class CurrentBet
    {
        public CitiStatus status { get; set; }

        public decimal currentPage { get; set; }

        public decimal totalPage { get; set; }

        public long lastUpdateDate { get; set; }

        public BetHistory matched { get; set; }

        public BetHistory unmatched { get; set; }
    }
}
