using System;
using System.Runtime.Serialization;

namespace Laixer.Kadaster.Exception
{
    [Serializable]
    public class RemoteProcedureTimeoutException : RemoteProcedureException
    {
        /// <summary>
        /// Create new instance.
        /// </summary>
        public RemoteProcedureTimeoutException() { }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="message">Error message.</param>
        public RemoteProcedureTimeoutException(string message)
            : base(message) { }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="inner">Inner exception.</param>
        public RemoteProcedureTimeoutException(string message, System.Exception inner)
            : base(message, inner) { }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Stream context.</param>
        protected RemoteProcedureTimeoutException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
