namespace Laixer.Kadaster
{
    /// <summary>
    /// Registration configuration.
    /// </summary>
    public sealed class KadasterConfig
    {
        /// <summary>
        /// Authorization access key.
        /// </summary>
        public string AuthKey { get; set; }

        /// <summary>
        /// Endpoint version.
        /// </summary>
        public int EndpointVersion { get; set; } = 1;
    }
}
