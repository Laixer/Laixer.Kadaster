using Newtonsoft.Json;

namespace Laixer.Kadaster.Internal
{
    /// <summary>
    /// Json serializer via Json.NET.
    /// </summary>
    internal class JsonNetSerializer : IJsonSerialzer
    {
        /// <summary>
        /// Deserializes the JSON to the specified .NET type.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="value">The JSON to deserialize.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        public virtual T DeserializeObject<T>(string value) => JsonConvert.DeserializeObject<T>(value);

        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public virtual string SerializeObject(object value) => JsonConvert.SerializeObject(value);
    }
}
