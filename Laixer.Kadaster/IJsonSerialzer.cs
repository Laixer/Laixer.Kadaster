namespace Laixer.Kadaster
{
    public interface IJsonSerialzer
    {
        string SerializeObject(object value);
        T DeserializeObject<T>(string value);
    }
}