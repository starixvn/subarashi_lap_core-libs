using Fanex.NVC.Authentication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fanex.NVC.Utils
{
    public static class BrandHelper
    {
        public static IDictionary<int, string> GetCurrencyList(IEnumerable<Brand> brands)
        {
            return brands.SelectMany(_ => _.CurrencyList)
                .GroupBy(_ => _.Key)
                .ToDictionary(x => x.Key, y => y.First().Value);
        }

        public static IDictionary<int, int[]> GetAgentList(IEnumerable<Brand> brands, int[] brandIds)
        {
            var combinedAgentList = new Dictionary<int, int[]>();
            foreach (var brandId in brandIds)
            {
                var brand = brands.FirstOrDefault(_ => _.Id == brandId);
                if (brand != null)
                {
                    CombineAgentList(combinedAgentList, brand.CurrencyAgentList);
                }
            }

            return combinedAgentList;
        }

        public static IDictionary<int, int[]> GetAgentList(IEnumerable<Brand> brands, string brandIdsString)
        {
            var brandIds = brandIdsString
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)).ToArray();

            return GetAgentList(brands, brandIds);
        }

        private static void CombineAgentList(IDictionary<int, int[]> targetAgentList, IDictionary<int, int[]> sourceAgentList)
        {
            foreach (var currencyAgent in sourceAgentList)
            {
                targetAgentList[currencyAgent.Key] = targetAgentList.ContainsKey(currencyAgent.Key) ?
                    targetAgentList[currencyAgent.Key].Union(currencyAgent.Value).ToArray() : currencyAgent.Value;
            }
        }
    }
}