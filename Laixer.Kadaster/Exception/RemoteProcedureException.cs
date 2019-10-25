using System;
using System.Runtime.Serialization;

namespace Laixer.Kadaster.Exception
{
    [Serializable]
    public class RemoteProcedureException : System.Exception
    {
        /// <summary>
        /// Create new instance.
        /// </summary>
        public RemoteProcedureException() { }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="message">Error message.</param>
        public RemoteProcedureException(string message)
            : base(message) { }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="inner">Inner exception.</param>
        public RemoteProcedureException(string message, System.Exception inner)
            : base(message, inner) { }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Stream context.</param>
        protected RemoteProcedureException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
