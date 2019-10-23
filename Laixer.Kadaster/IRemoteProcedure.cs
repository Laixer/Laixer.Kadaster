namespace Laixer.Kadaster
{
    public interface IRemoteProcedure
    {
        string Query(string uri);

        TReturn Query<TReturn>(string uri);

        string Execute(string uri, object obj);

        TReturn Execute<TReturn>(string uri, object obj);

        IJsonSerialzer JsonSerialzer { get; set; }
    }
}
