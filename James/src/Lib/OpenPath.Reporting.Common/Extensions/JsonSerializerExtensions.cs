using Newtonsoft.Json;
using OpenPath.Reporting.Common.Extensions;
using System.IO;

namespace OpenPath.Reporting.Common.Extensions
{
    /// <summary>
    /// Json Serializer Extensions
    /// </summary>
    public static class JsonSerializerExtensions
    {
        /// <summary>
        /// Extension method. Deserializes a stream into an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize into.</typeparam>
        /// <param name="serializer">The JsonSerializer</param>
        /// <param name="s">A stream</param>
        /// <returns>A seralized object or null.</returns>
        public static T Deserialize<T>(this JsonSerializer serializer, Stream s)
        {
            if (serializer == null)
            {
                return default;
            }

            if (s == null || !s.CanRead)
            {
                return default;
            }

            using (var streamReader = new StreamReader(s))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }

}
