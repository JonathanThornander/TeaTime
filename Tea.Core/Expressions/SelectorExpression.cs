using System;

namespace Tea.Core.Expressions
{
    public abstract class SelectorExpression : Expression
    {
        private readonly bool _negate;

        protected SelectorExpression(bool negate)
        {
            _negate = negate;
        }

        public override DateTime? NextOccurance(DateTime reference)
        {
            if (_negate)
            {
                return GetNextNegate(reference);
            }

            return GetNext(reference);
        }

        protected abstract DateTime? GetNextNegate(DateTime reference);
    }
}
