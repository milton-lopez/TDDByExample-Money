using TDDByExampleMoney.App;
using Xunit;

namespace TDDByExampleMoney.Tests
{
    public class BankTests
    {
        [Fact]
        public void IdentityRateReturnsCorrectResult()
        {
            var bank = new Bank();
            Assert.Equal(1, bank.Rate("USD", "USD"));
        }
    }
}
