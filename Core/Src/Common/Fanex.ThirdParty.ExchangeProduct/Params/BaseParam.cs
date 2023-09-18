using Fanex.ThirdParty.ExchangeProduct.Constant;
using System;


namespace Fanex.ThirdParty.ExchangeProduct.Params
{
    public class BaseParam
    {
        public string TimeStamp { get; set; } = DateTime.Now.ToString(DateTimeConstant.TimeStampFormat);

        public string Seq { get; set; } = Guid.NewGuid().ToString();
    }
}
