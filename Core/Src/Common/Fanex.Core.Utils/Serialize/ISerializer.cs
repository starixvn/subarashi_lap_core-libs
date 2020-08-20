namespace Fanex.Core.Utils
{
    public interface ISerializer
    {
        T Deserialize<T>(byte[] serializedModel);

        byte[] Serialize<T>(T model);
    }
}