using System;
using System.Runtime.Serialization;

namespace Tea.Core.Exceptions
{
    [Serializable]
    public class ExpressionValidationException : Exception
    {
        public ExpressionValidationException()
        {
        }

        public ExpressionValidationException(string? message) : base(message)
        {
        }

        public ExpressionValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ExpressionValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}