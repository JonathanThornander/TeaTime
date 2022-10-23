using System;
using System.Linq;
using System.Text;
using Tea.Core.LINQExtensions;
using static Tea.Core.LINQExtensions.DateTimeExtensions;

namespace Tea.Core.Expressions.Functional
{
    public class AndFunction : Expression
    {
        private readonly Expression[] _expressions;

        public AndFunction(Expression[] expressions)
        {
            _expressions = expressions;
        }

        internal override string GetSignature()
        {
            var sb = new StringBuilder();
            var inner = _expressions.Select(x => x.GetSignature());

            sb.Append("AND(");

            foreach (var expressionRepr in inner)
            {
                sb.Append(expressionRepr);
                sb.Append(" ");
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            return sb.ToString();
        }

        protected override DateTime? GetNext(DateTime reference)
        {
            while (true)
            {
                var traverseResult = _expressions
                    .Select(exp => exp.NextOccurance(reference))
                    .Traverse();

                if (traverseResult is NullTraverseResult)
                {
                    return null;
                }
                if (traverseResult is AllEqualTraverseResult result)
                {
                    return result.Value;
                }

                reference = ((UnequalResult)traverseResult).Max;
            }
        }

        internal override ValidationResult Validate()
        {
            if (_expressions.Length == 0)
            {
                return new ValidationResult(false, "At least one expression is required");
            }

            var unvalidInnerExpressions = _expressions
                .Select(exp => exp.Validate())
                .Where(validationResult => validationResult.Valid == false)
                .ToArray();

            if (unvalidInnerExpressions.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{unvalidInnerExpressions.Length} inner expressions of AllFunction are not valid:");

                foreach (var unvalidValidation in unvalidInnerExpressions)
                {
                    sb.AppendLine(unvalidValidation.Message);
                }

                return new ValidationResult(false, sb.ToString());
            }

            return new ValidationResult(true);
        }
    }
}
