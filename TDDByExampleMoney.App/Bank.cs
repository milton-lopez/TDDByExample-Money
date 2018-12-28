using System.Collections.Generic;

namespace TDDByExampleMoney.App
{
    public class Bank
    {
        private IDictionary<CurrencyPair, int> _rates = new Dictionary<CurrencyPair, int>();

        public Money Reduce(Expression source, string to) =>
            source.Reduce(this, to);

        public void AddRate(string from, string to, int rate) =>
            _rates.Add(new CurrencyPair(from, to), rate);

        public int Rate(string from, string to) =>
            from.Equals(to) ? 1 : _rates[new CurrencyPair(from, to)];
    }
}
