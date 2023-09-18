using Fanex.ThirdParty.ExchangeProduct.Enums;

namespace Fanex.ThirdParty.ExchangeProduct.Params
{
    public class UpdateCommissionParam : BaseParam
    {
        public int CustId { get; set; }

        public double Commission { get; set; }

        public int GroupMode { get; set; }
    }
}
