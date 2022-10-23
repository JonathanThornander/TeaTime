using System;
using System.Runtime.Serialization;

namespace TeaTime
{
    [Serializable]
    internal class TeaTimeException : Exception
    {
        public TeaTimeException()
        {
        }

        public TeaTimeException(string message) : base(message)
        {
        }

        public TeaTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TeaTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}