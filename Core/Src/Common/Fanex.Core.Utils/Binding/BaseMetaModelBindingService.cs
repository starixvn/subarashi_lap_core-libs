using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fanex.Core.Utils
{
    public class BaseMetaModelBindingService : IMetaModelBindingService
    {
        public void BindAgentXml(IDictionary<string, object> actionArguments, IDictionary<int, int[]> currencyAgentList)
        {
            if (MetaModelHelper.IsMetaModel(actionArguments, out IAgentMetaModel itemWithAgent))
            {
                var currencyIdList = string.Empty;
                if (MetaModelHelper.IsMetaModel(actionArguments, out ICurrencyIdListMetaModel itemWithCurrencyIdList))
                {
                    currencyIdList = itemWithCurrencyIdList.CurrencyIdList;
                }
                else if (MetaModelHelper.IsMetaModel(actionArguments, out ICurrencyIdMetaModel itemWithCurrencyId))
                {
                    currencyIdList = itemWithCurrencyId.CurrencyId.ToString();
                }
                else
                {
                    //no thing
                }

                var isExcludedTestData = MetaModelHelper.IsMetaModel(actionArguments, out IDataTestableMetaModel itemWithExcludedTestData) && itemWithExcludedTestData.IsExcludedTestData;

                itemWithAgent.AgentListXml = GenerateAgentListXml(currencyAgentList, currencyIdList, isExcludedTestData);
            }
        }

        public void BindPlayerCom(IDictionary<string, object> actionArguments, bool hasPlayerCom)
        {
            if (MetaModelHelper.IsMetaModel(actionArguments, out IPlayerComMetaModel itemWitPlayerCom))
            {
                itemWitPlayerCom.HasPlayerCom = hasPlayerCom;
            }
        }

        protected static string GenerateAgentListXml(IDictionary<int, int[]> currencyAgentList, string currencyIdList, bool isExcludeTestData = false)
        {
            if (currencyAgentList == null || !currencyAgentList.Any())
            {
                return string.Empty;
            }

            if (isExcludeTestData && currencyAgentList.ContainsKey(CurrencyType.Uus))
            {
                currencyAgentList = currencyAgentList
                    .Where(_ => _.Key != CurrencyType.Uus)
                    .ToDictionary(_ => _.Key, _ => _.Value);
            }

            var actualCurrencyAgentList = GetSelectedCurrencyAgentList(currencyAgentList, currencyIdList);

            var builder = new StringBuilder("<ROOT>");
            foreach (var currencyItem in actualCurrencyAgentList)
            {
                var xmlItemList = currencyItem.Value.Select(x => $"<Agent AgentId=\"{x}\" Currency=\"{currencyItem.Key}\"/>");
                builder.Append(string.Join("", xmlItemList));
            }

            builder.Append("</ROOT>");

            return builder.ToString();
        }

        protected static IDictionary<int, int[]> GetSelectedCurrencyAgentList(IDictionary<int, int[]> currencyAgentList, string currencyIdList)
        {
            if (string.IsNullOrEmpty(currencyIdList))
            {
                return currencyAgentList;
            }

            var selectedCurrencyIdList = ParseCurrencyIdList(currencyIdList);
            if (selectedCurrencyIdList.Any(_ => _ <= 0))
            {
                return currencyAgentList;
            }

            return currencyAgentList
                .Where(x => selectedCurrencyIdList.Contains(x.Key))
                .ToDictionary(_ => _.Key, _ => _.Value);
        }

        private static IEnumerable<int> ParseCurrencyIdList(string currencyIdList)
        {
            var selectedCurrencyIdList = currencyIdList.Trim()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Convert.ToInt32(x));

            return selectedCurrencyIdList;
        }
    }
}