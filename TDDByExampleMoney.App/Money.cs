namespace TDDByExampleMoney.App
{
    public class Money : Expression
    {
        public int Amount { get; }
        public string Currency { get; }

        public Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Dollar(int amount) =>
            new Money(amount, "USD");

        public static Money Franc(int amount) =>
            new Money(amount, "CHF");

        public override Expression Plus(Expression addend) =>
            new Sum(this, addend);

        public override Money Reduce(Bank bank, string to)
        {
            var rate = bank.Rate(Currency, to);
            return new Money(Amount / rate, to);
        }

        public override string ToString() =>
            Amount + " " + Currency;

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return Amount == money.Amount && Currency.Equals(money.Currency);
        }

        public override int GetHashCode() =>
            Amount.GetHashCode() ^ Currency.GetHashCode();
    }
}