

namespace Fanex.ThirdParty.ExchangeProduct
{
    public class ResponseResult<T> where T : class
    {
        public string TimeStamp { get; set; }

        public string Seq { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorDescription { get; set; }

        public T Result { get; set; }
    }
}
