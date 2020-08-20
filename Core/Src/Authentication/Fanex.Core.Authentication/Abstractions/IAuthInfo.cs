namespace Fanex.Core.Authentication.Abstractions
{
    public interface IAuthInfo 
    {
    }

    public interface IAuthInfo<TLicensee, TUser> : IAuthInfo
        where TLicensee : ILicenseeAuthInfo
        where TUser : IUserAuthInfo
    {
        TLicensee LicenseeAuthInfo { get; set; }
        TUser UserAuthInfo { get; set; }
    }
}