using System;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    public class ReSettleSummaryTransactionData
    {
        public int betId { get; set; }

        public string selectionName { get; set; }

        public decimal txOddsMatched { get; set; }

        public decimal txStake { get; set; }

        public string matchType { get; set; }

        public DateTime? placed { get; set; }

        public decimal txLiability { get; set; }
    }
}
