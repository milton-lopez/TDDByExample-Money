using System.Linq;

namespace TDDByExampleMoney.App
{
    public abstract class Expression
    {
        public abstract Money Reduce(Bank bank, string to);
        public abstract Expression Plus(Expression addend);

        public Expression Times(int multiplier) =>
            Enumerable.Repeat(this, multiplier)
                      .Aggregate((x, y) => x.Plus(y));
    }
}