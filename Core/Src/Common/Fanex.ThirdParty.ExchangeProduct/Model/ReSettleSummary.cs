using Fanex.ThirdParty.ExchangeProduct.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    public class ReSettleSummary
    {
        public CitiStatus status { get; set; }

        public int currentPage { get; set; }

        public int totalPage { get; set; }

        public List<ReSettleSummaryResultList> resultList { get; set; }

        public List<ReSettleSummarySportList> sportList { get; set; }

        public decimal totalPL { get; set; }
    }
}
