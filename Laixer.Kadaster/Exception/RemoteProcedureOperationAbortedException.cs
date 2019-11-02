using System;
using System.Runtime.Serialization;

namespace Laixer.Kadaster.Exception
{
    [Serializable]
    public class RemoteProcedureOperationAbortedException : RemoteProcedureException
    {
        /// <summary>
        /// Create new instance.
        /// </summary>
        public RemoteProcedureOperationAbortedException() { }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="message">Error message.</param>
        public RemoteProcedureOperationAbortedException(string message)
            : base(message) { }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="inner">Inner exception.</param>
        public RemoteProcedureOperationAbortedException(string message, System.Exception inner)
            : base(message, inner) { }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Stream context.</param>
        protected RemoteProcedureOperationAbortedException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
