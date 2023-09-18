using Fanex.ThirdParty.ExchangeProduct.Enums;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    public class BetHistoryForAllStatus
    {
        public CitiStatus status { get; set; }

        public BetHistory settled { get; set; }

        public BetHistory cancelled { get; set; }

        public BetHistory voided { get; set; }
    }
}
