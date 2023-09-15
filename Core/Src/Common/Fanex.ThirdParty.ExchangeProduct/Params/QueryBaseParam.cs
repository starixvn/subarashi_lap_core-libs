using System;

namespace Fanex.ThirdParty.ExchangeProduct.Params
{
    public class QueryBaseParam : BaseParam
    { 
        public int CustId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PageNumber { get; set; }

        public int ReportType { get; set; }

        public int GroupMode { get; set; }
    }
}
