using System.Collections.Generic;
using TDDByExampleMoney.App;

namespace TDDByExampleMoney.Tests
{
    public class ExpressionEqualityComparer : IEqualityComparer<Expression>
    {
        private readonly Bank bank;

        public ExpressionEqualityComparer()
        {
            bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
        }

        public bool Equals(Expression x, Expression y)
        {
            var xReduced = bank.Reduce(x, "USD");
            var yReduced = bank.Reduce(y, "USD");
            return object.Equals(xReduced, yReduced);
        }

        public int GetHashCode(Expression obj) =>
            bank.Reduce(obj, "USD").GetHashCode();
    }
}
