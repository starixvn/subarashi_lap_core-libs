using System;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    [Serializable]
    public class SettleBetHistoryTransactionData
    {
        public DateTime? betTaken { get; set; }

        public decimal txStake { get; set; }

        public decimal txOddsMatched { get; set; }

        public decimal actualOdds { get; set; }

        public int? txFancyBetRuns { get; set; }
    }
}
