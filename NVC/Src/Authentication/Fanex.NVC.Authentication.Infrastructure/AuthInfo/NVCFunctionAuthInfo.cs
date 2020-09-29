using System;

namespace Fanex.NVC.Authentication.Infrastructure
{
    [Serializable]
    public class NVCFunctionAuthInfo
    {
        public int FunctionId { get; set; }

        public string FunctionKey { get; set; }

        public int ParentId { get; set; }

        public int Policy { get; set; }
    }
}