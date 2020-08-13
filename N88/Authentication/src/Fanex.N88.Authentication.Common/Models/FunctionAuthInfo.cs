using System;

namespace Fanex.N88.Authentication.Common.Models
{
    [Serializable]
    public class FunctionAuthInfo
    {
        public int FunctionId { get; set; }

        public string FunctionKey { get; set; }

        public string Description { get; set; }

        public int ParentId { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsNew { get; set; }

        public int Policy { get; set; }
    }
}