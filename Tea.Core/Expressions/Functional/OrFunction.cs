using System.Text;

namespace Tea.Core.Expressions.Functional
{
    public class OrFunction : Expression
    {
        private readonly Expression[] _expressions;

        public OrFunction(Expression[] expressions)
        {
            _expressions = expressions;
        }

        protected override DateTime? GetNext(DateTime reference)
        {
            if (_expressions.Length == 0)
            {
                throw new Exception("At least one expression is required");
            }

            return _expressions
                .Select(exp => exp.NextOccurance(reference))
                .Min();
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

                sb.AppendLine($"{unvalidInnerExpressions.Length} inner expressions of AnyFunction are not valid:");

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
