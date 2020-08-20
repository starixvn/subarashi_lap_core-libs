using System.Collections.Generic;

namespace Fanex.Core.Utils.Binding
{
    public interface IMetaModelBindingService
    {
        void BindAgentXml(IDictionary<string, object> actionArguments, IDictionary<int, int[]> currencyAgentList);

        void BindPlayerCom(IDictionary<string, object> actionArguments, bool hasPlayerCom);
    }
}