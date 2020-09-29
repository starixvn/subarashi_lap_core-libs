using System.Collections.Generic;
using System.Linq;

namespace Fanex.Core.Utils
{
    public static class MetaModelHelper
    {
        public static bool IsMetaModel<T>(IDictionary<string, object> actionArguments, out T model)
            where T : class
        {
            var metaModel = actionArguments.FirstOrDefault(x => x.Value is T);
            if (metaModel.Value is T value)
            {
                model = value;
                return true;
            }
            model = null;
            return false;
        }
    }
}