using CoinJarServices;

namespace CoinJarServicesTests
{
    public class CoinJarServicesTest
    {
        private readonly ICoinJar _service;
        public CoinJarServicesTest()
        {
            _service = new CoinJarService();
        }
        [Fact]
        public void Test_AmountCoinsAdded_ToPiggyBankList()
        {
            _service.AddCoin(new CoinService
            {
                Amount = 1,
                Volume = 3
            });
            _service.AddCoin(new CoinService
            {
                Amount = 1,
                Volume = 3
            });

            var total = _service.GetTotalAmount();
            Assert.Equal(2, total);
        }

        [Fact]
        public void Test_CoinsAdded_More42Ounces_ThrowException()
        {


            var exception = Assert.Throws<Exception>(() =>
            _service.AddCoin(new CoinService
            {
                Amount = 2,
                Volume = 22
            }));
            Assert.Equal("Sorry you have exceeded the capacity of the piggy bank which 42 ounce", exception.Message);

        }

        [Fact]
        public void Test_ClearsTotalAmountInPiggyBankList()
        {
            _service.Reset();

            var total = _service.GetTotalAmount();
            Assert.Equal(0, total);
        }

        [Fact]
        public void Test_CalculatedVolumeOfCoin_Returns_VolumeOfCoin()
        {
            _service.AddCoin(new CoinService
            {
                Amount = 1,
                Volume = 3
            });
            _service.AddCoin(new CoinService
            {
                Amount = 1,
                Volume = 3
            });
            Assert.Equal(6, _service.GetVolume());
        }
    }
}