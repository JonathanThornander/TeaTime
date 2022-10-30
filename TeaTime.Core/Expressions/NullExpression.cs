using System;

namespace TeaTime.Core.Expressions
{
    public class NullExpression : Expression
    {
        protected override DateTime? GetNext(DateTime reference) => null;

        internal override string GetSignature() => string.Empty;

        internal override ValidationResult Validate()
        {
            return new ValidationResult(false, "Null expressions does not yield");
        }
    }
}
