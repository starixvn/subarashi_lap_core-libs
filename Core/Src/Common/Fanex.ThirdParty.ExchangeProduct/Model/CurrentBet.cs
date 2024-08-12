using Fanex.ThirdParty.ExchangeProduct.Enums;
using System;
using System.Collections.Generic;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    [Serializable]
    public class CurrentBet
    {
        public CitiStatus status { get; set; }

        public decimal currentPage { get; set; }

        public decimal totalPage { get; set; }

        public decimal totalCount { get; set; }

        public List<BetHistoryResultList> resultList { get; set; }
    }
}
