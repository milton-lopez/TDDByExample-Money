using TDDByExampleMoney.App;
using Xunit;

namespace TDDByExampleMoney.Tests
{
    public class SumTests
    {
        [Fact]
        public void ReduceReturnsCorrectResult()
        {
            //Arrange
            Expression sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            Bank bank = new Bank();

            //Act
            Money reduced = bank.Reduce(sum, "USD");

            //Assert
            Assert.Equal(Money.Dollar(7), reduced);
        }

        [Fact]
        public void PlusReturnsCorrectResult()
        {
            //Arrange
            Expression fiveDollars = Money.Dollar(5);
            Expression tenFrancs = Money.Franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            //Act
            Expression sum = new Sum(fiveDollars, tenFrancs).Plus(fiveDollars);
            Money result = bank.Reduce(sum, "USD");

            //Assert
            Assert.Equal(Money.Dollar(15), result);
        }

        [Fact]
        public void TimesReturnsCorrectResult()
        {
            //Arrange
            Expression fiveDollars = Money.Dollar(5);
            Expression tenFrancs = Money.Franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            //Act
            Expression sum = new Sum(fiveDollars, tenFrancs).Times(2);
            Money result = bank.Reduce(sum, "USD");

            //Assert
            Assert.Equal(Money.Dollar(20), result);
        }
    }
}
