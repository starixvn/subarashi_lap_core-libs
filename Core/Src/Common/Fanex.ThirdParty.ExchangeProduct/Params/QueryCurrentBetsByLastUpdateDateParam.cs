

namespace Fanex.ThirdParty.ExchangeProduct.Params
{
    public class QueryCurrentBetsByLastUpdateDateParam : BaseParam
    {
        public long LastUpdateDate { get; set; }

        public bool IsTxnDetail { get; set; }

        public int PageNumber { get; set; }

        public int ReportType { get; set; }

        public int GroupMode { get; set; }
    }
}
