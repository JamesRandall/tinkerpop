using System.Collections;
using System.Collections.Generic;

namespace Gremlin.Net.Driver
{
    /// <summary>
    /// Wraps a Gremlin response and exposes the servers attribute set and status code
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GremlinResponse<T> : IReadOnlyCollection<T>
    {
        /// <summary>
        /// The deserialized results
        /// </summary>
        public IReadOnlyCollection<T> Results { get; internal set; }

        /// <summary>
        /// Attributes returned from the server
        /// </summary>
        public IDictionary<string, object> Attributes { get; internal set; }

        /// <summary>
        /// The status code returned from the server
        /// </summary>
        public int StatusCode { get; internal set; }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Results.GetEnumerator();
        }

        int IReadOnlyCollection<T>.Count => Results.Count;
    }
}
