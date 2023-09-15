using Fanex.ThirdParty.ExchangeProduct.Enums;
using System;


namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    [Serializable]
    public class GetProfile
    {
        public CitiStatus status { get; set; }

        public string userId { get; set; }

        public decimal exposureLimit { get; set; }

        public decimal maxWinLimit { get; set; }

        public decimal? profitloss { get; set; }

        public string acountStatus { get; set; }

        public string lastName { get; set; }

        public decimal commission { get; set; }
    }
}
