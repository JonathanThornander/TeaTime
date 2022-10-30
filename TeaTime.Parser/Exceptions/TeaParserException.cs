using System;
using System.Runtime.Serialization;

namespace TeaTime.Parser.Exceptions
{
    [Serializable]
    internal class TeaParserException : Exception
    {
        public TeaParserException()
        {
        }

        public TeaParserException(string message) : base(message)
        {
        }

        public TeaParserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TeaParserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}