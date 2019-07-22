using System;
using System.Net;

namespace Microsoft.DSX.ProjectTemplate.Data.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        protected ExceptionBase(string message, string messageHeader = null)
            : base(message)
        {
            MessageHeader = messageHeader;
        }

        public abstract HttpStatusCode StatusCode { get; }

        public string MessageHeader { get; }
    }
}
