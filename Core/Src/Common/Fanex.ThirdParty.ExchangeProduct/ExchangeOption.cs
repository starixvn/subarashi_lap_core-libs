using Fanex.ThirdParty.ExchangeProduct.Constant;

namespace Fanex.ThirdParty.ExchangeProduct
{
    public class ExchangeOption
    {
        public string BaseAddress { get; set; }

        public string UrlGetProfile { get; set; } = UrlEndPoint.GetProfile;

        public string UrlUpdateCommission { get; set; } = UrlEndPoint.UpdateCommision;

        public string UrlQueryReSettleSummaryTransaction { get; set; } = UrlEndPoint.QueryReSettleSummaryTransaction;

        public string UrlQuerySettleBetHistory { get; set; } = UrlEndPoint.QuerySettleBetHistory;

        public string UrlQuerySummaryTransaction { get; set; } = UrlEndPoint.QuerySummaryTransaction;

        public string UrlQueryBetHistoryForAllStatus { get; set; } = UrlEndPoint.QueryBetHistoryForAllStatus;

        public string UrlQueryCurrentBetsByLastTime { get; set; } = UrlEndPoint.QueryCurrentBetsByLastUpdateDate;
    }
}
