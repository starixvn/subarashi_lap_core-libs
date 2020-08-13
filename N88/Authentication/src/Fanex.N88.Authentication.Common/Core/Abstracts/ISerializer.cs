namespace Fanex.N88.Authentication.Common.Core
{
    public interface ISerializer
    {
        T Deserialize<T>(byte[] serializedModel);

        byte[] Serialize<T>(T model);
    }
}