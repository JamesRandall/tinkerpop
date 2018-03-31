using System.Collections;
using System.Collections.Generic;

namespace Gremlin.Net.Driver
{
    /// <summary>
    /// Wraps a Gremlin response and exposes the servers attribute set and status code
    /// </summary>
    public class GremlinResponse
    {
        internal GremlinResponse(
            IReadOnlyCollection<IDictionary<string, object>> attributes,
            IReadOnlyCollection<int> statusCodes
        )
        {
            Attributes = attributes;
            StatusCodes = statusCodes;
        }

        /// <summary>
        /// Attributes returned from the server
        /// </summary>
        public IReadOnlyCollection<IDictionary<string, object>> Attributes { get; set; }

        /// <summary>
        /// The status code returned from the server
        /// </summary>
        public IReadOnlyCollection<int> StatusCodes { get; set; }
    }

    /// <summary>
    /// Wraps a Gremlin response and exposes the servers attribute set and status code
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GremlinResponse<T> : GremlinResponse, IReadOnlyCollection<T>
    {
        internal GremlinResponse(IReadOnlyCollection<T> results,
            IReadOnlyCollection<IDictionary<string, object>> attributes,
            IReadOnlyCollection<int> statusCodes
        ) : base(attributes, statusCodes)
        {
            Results = results;
        }

        /// <summary>
        /// The deserialized results
        /// </summary>
        public IReadOnlyCollection<T> Results { get; set; }

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
