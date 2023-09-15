using Fanex.ThirdParty.ExchangeProduct.Enums;

namespace Fanex.ThirdParty.ExchangeProduct.Params
{
    public class QueryBetHistoryForAllStatusParam : QueryBaseParam
    {
        public BetStatusHistory BetStatus { get; set; }

        public bool IsTxnDetail { get; set; }
    }
}
