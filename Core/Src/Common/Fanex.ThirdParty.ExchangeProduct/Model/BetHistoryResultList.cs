using System;
using System.Collections.Generic;


namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    [Serializable]
    public class BetHistoryResultList
    {
        public string eventTypeName { get; set; }

        public string eventName { get; set; }

        public int eventId { get; set; }

        public int site { get; set; }

        public int categoryType { get; set; }

        public int currencyType { get; set; }

        public int eventType { get; set; }

        public string marketName { get; set; }

        public string marketId { get; set; }

        public string selectionName { get; set; }

        public long selectionId { get; set; }

        public string matchType { get; set; }

        public long betId { get; set; }

        public DateTime? betPlaced { get; set; }

        public string ip { get; set; }

        public string ips { get; set; }

        public decimal matchOddsReq { get; set; }

        public decimal reduction { get; set; }

        public string userId { get; set; }

        public int? fancyBetRuns { get; set; }

        public int? fancyBetExtendedRuns { get; set; }

        public int? fancyBetMarketType { get; set; }

        public string extension1 { get; set; }

        public List<SettleBetHistoryTransactionData> transactionData { get; set; }

        public decimal matchStake { get; set; }

        public decimal matchAvgOdds { get; set; }

        public decimal? profitloss { get; set; }

        public long? updateDate { get; set; }

        public string betStatus { get; set; }

        public string agentId { get; set; }

        public int? oddsType { get; set; }

        public DateTime? matchSettledDate { get; set; }

        public DateTime? marketSettledDate { get; set; }

        public decimal matchAmount { get;set; }

        public decimal unMatchAmount { get; set; }

        public DateTime? dateMatched { get; set; }
    }
}
