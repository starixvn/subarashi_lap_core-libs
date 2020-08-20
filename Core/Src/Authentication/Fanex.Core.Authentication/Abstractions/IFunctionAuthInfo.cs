namespace Fanex.Core.Authentication.Abstractions
{
    public interface IFunctionAuthInfo
    {
        int FunctionId { get; set; }

        string FunctionKey { get; set; }

        int ParentId { get; set; }

        bool IsActive { get; set; }
    }
}