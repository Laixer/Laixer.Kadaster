namespace Laixer.Kadaster
{
    /// <summary>
    /// Interface for remote procedure caller.
    /// </summary>
    public interface IRemoteProcedure
    {
        /// <summary>
        /// Perform query with result based on uri.
        /// </summary>
        /// <param name="uri">Request uri.</param>
        /// <returns>Result as string, if any.</returns>
        string Query(string uri);

        /// <summary>
        /// Perform query with result based on uri.
        /// </summary>
        /// <typeparam name="TReturn">Return type.</typeparam>
        /// <param name="uri">Request uri.</param>
        /// <returns>Object of type <typeparamref name="TReturn"/>.</returns>
        TReturn Query<TReturn>(string uri);

        /// <summary>
        /// Execute request and result result.
        /// </summary>
        /// <param name="uri">Request uri.</param>
        /// <param name="obj">Object to submit.</param>
        /// <returns>Result as string, if any.</returns>
        string Execute(string uri, object obj);

        /// <summary>
        /// Execute request and result result.
        /// </summary>
        /// <typeparam name="TReturn">Return type.</typeparam>
        /// <param name="uri">Request uri.</param>
        /// <param name="obj">Object to submit.</param>
        /// <returns>Object of type <typeparamref name="TReturn"/>.</returns>
        TReturn Execute<TReturn>(string uri, object obj);

        /// <summary>
        /// Json object serializer. See <see cref="IJsonSerialzer"/>.
        /// </summary>
        IJsonSerialzer JsonSerialzer { get; set; }
    }
}
