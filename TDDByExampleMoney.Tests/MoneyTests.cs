using TDDByExampleMoney.App;
using Xunit;

namespace TDDByExampleMoney.Tests
{
    public class MoneyTests
    {
        [Fact]
        public void EqualsReturnsCorrectResult()
        {
            Assert.Equal(Money.Dollar(5), Money.Dollar(5));
            Assert.NotEqual(Money.Dollar(5), Money.Dollar(6));
            Assert.NotEqual(Money.Franc(5), Money.Dollar(5));
        }

        [Fact]
        public void MultiplicationReturnsCorrectResult()
        {
            Money five = Money.Dollar(5);
            Assert.Equal(Money.Dollar(10), five.Times(2), new ExpressionEqualityComparer());
            Assert.Equal(Money.Dollar(15), five.Times(3), new ExpressionEqualityComparer());
        }

        [Fact]
        public void CurrencyReturnsCorrectResult()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency);
            Assert.Equal("CHF", Money.Franc(1).Currency);
        }

        [Fact]
        public void AdditionReturnsCorrectResult()
        {
            //Arrange
            var five = Money.Dollar(5);
            var sum = five.Plus(five);
            var bank = new Bank();

            //Act
            var reduced = bank.Reduce(sum, "USD");

            //Assert
            Assert.Equal(Money.Dollar(10), reduced);
        }

        [Fact]
        public void PlusReturnsCorrectResultOfTypeSum()
        {
            //Arrange
            var five = Money.Dollar(5);
            var result = five.Plus(five);

            //Assert
            var sum = Assert.IsType<Sum>(result);
            Assert.Equal(five, sum.Augend);
            Assert.Equal(five, sum.Addend);
        }

        [Fact]
        public void ReduceReturnsCorrectResult()
        {
            //Arrange
            var bank = new Bank();

            //Act
            var reduced = bank.Reduce(Money.Dollar(1), "USD");

            //Assert
            Assert.Equal(Money.Dollar(1), reduced);
        }

        [Fact]
        public void ReduceWithDifferentCurrenciesReturnsCorrectResult()
        {
            //Arrange
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            //Act
            var result = bank.Reduce(Money.Franc(2), "USD");

            //Assert
            Assert.Equal(Money.Dollar(1), result);
        }

        [Fact]
        public void AdditionWithDifferentCurrenciesReturnsCorrectResult()
        {
            //Arrange
            Expression fiveDollars = Money.Dollar(5);
            Expression tenFrancs = Money.Franc(10);
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            //Act
            var result = bank.Reduce(fiveDollars.Plus(tenFrancs), "USD");

            //Assert
            Assert.Equal(Money.Dollar(10), result);
        }
    }

}
