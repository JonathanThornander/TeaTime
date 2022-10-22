using System;
using System.Runtime.Serialization;

namespace TeaTime
{
    [Serializable]
    internal class TeaTimeExpression : Exception
    {
        public TeaTimeExpression()
        {
        }

        public TeaTimeExpression(string message) : base(message)
        {
        }

        public TeaTimeExpression(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TeaTimeExpression(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}