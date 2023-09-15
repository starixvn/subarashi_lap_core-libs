using Fanex.ThirdParty.ExchangeProduct.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fanex.ThirdParty.ExchangeProduct.Model
{
    [Serializable]
    public class Summary
    {
        public CitiStatus status { get; set; }

        public int currentPage { get; set; }

        public int totalPage { get; set; }

        public List<SummaryResultList> resultList { get; set; }

        public List<SummarySportList> sportList { get; set; }

        public decimal totalPL { get; set; }
    }
}
