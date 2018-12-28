﻿namespace TDDByExampleMoney.App
{
    public class CurrencyPair
    {
        private readonly string _from;
        private readonly string _to;

        public CurrencyPair(string from, string to)
        {
            _from = from;
            _to = to;
        }

        public override bool Equals(object obj)
        {
            var pair = (CurrencyPair)obj;
            return _from.Equals(pair._from) && _to.Equals(pair._to);
        }

        public override int GetHashCode() =>
            (_from + _to).GetHashCode();
    }
}