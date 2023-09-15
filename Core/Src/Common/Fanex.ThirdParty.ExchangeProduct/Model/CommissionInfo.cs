using Fanex.ThirdParty.ExchangeProduct.Enums;
using System;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    [Serializable]
    public class CommissionInfo
    {
        public CitiStatus status { get; set; }

        public double commission { get; set; }
    }
}
