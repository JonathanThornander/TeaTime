using System.Text;
using Tea.Core.LINQExtensions;
using static Tea.Core.LINQExtensions.DateTimeSequenceExtensions;

namespace Tea.Core.Expressions.Functional
{
    public class AndFunction : Expression
    {
        private readonly Expression[] _expressions;

        public AndFunction(Expression[] expressions)
        {
            _expressions = expressions;
        }

        protected override DateTime? GetNext(DateTime reference)
        {
            if (_expressions.Length == 0)
            {
                throw new Exception("At least one expression is required");
            }

            while (true)
            {
                var traverseResult = _expressions
                    .Select(exp => exp.NextOccurance(reference))
                    .Traverse();

                switch (traverseResult)
                {
                    case NullTraverseResult:
                        return null;
                    case AllEqualTraverseResult:
                        return ((AllEqualTraverseResult)traverseResult).Value;
                    case UnequalResult:
                        reference = ((UnequalResult)traverseResult).Max;
                        break;
                }
            }
        }

        internal override ValidationResult Validate()
        {
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

            //var duplicates = _expressions
            //    .GroupBy(exp => exp.GetType())
            //    .Where(group => group.Count() > 1)
            //    .Select(x => x.Key)
            //    .ToArray();

            //if (duplicates.Any())
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append($"And function cannot contain multiple expressions of same type. The following expressions occured more than once: '");

            //    foreach (var duplicate in duplicates)
            //    {
            //        sb.Append(duplicate.Name);
            //        sb.Append(", ");
            //    }

            //    sb.Remove(sb.Length - 2, 2);
            //    sb.Append("'");

            //    return new ValidationResult(false, sb.ToString());
            //}


            return new ValidationResult(true);
        }
    }


}
