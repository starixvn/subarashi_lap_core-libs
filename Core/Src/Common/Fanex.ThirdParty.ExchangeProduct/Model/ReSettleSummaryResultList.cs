using System;
using System.Collections.Generic;
using System.Text;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    public class ReSettleSummaryResultList
    {
        public string userId { get; set; }

        public string agentId { get; set; }

        public string eventTypeName { get; set; }

        public string eventName { get; set; }

        public int eventId { get; set; }

        public string marketName { get; set; }

        public string marketId { get; set; }

        public DateTime? startTime { get; set; }

        public DateTime? settledDate { get; set; }

        public DateTime? resettledDate { get; set; }

        public decimal? profitloss { get; set; }

        public decimal marketTotal { get; set; }

        public decimal commission { get; set; }

        public decimal agentCommission { get; set; }

        public decimal stakeTotal { get; set; }

        public List<ReSettleSummaryTransactionData> transactionData { get; set; }

        public decimal backSubTotal { get; set; }

        public decimal laySubTotal { get; set; }

        public int? categoryType { get; set; }

        public int? eventType { get; set; }

        public int? currencyType { get; set; }

        public int? oddsType { get; set; }

    }
}
