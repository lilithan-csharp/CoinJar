namespace CoinJarServices
{
    public class CoinJarService : ICoinJar
    {
        private readonly List<ICoin> piggyBankList = new List<ICoin>() { };

        public void AddCoin(ICoin coin)
        {
            decimal totalVolume = GetVolume();
            decimal capacity = (coin.Volume * coin.Amount) + totalVolume;
        
            if (capacity > 42)
            {
                throw new Exception("Sorry you have exceeded the capacity of the piggy bank which 42 ounce");
            }
            piggyBankList.Add(coin);
        }

        public decimal GetTotalAmount()
        {
            var totalAmount = 0m;
            for (int i = 0; i < piggyBankList.Count; i++)
            {
                totalAmount +=  piggyBankList[i].Amount;
            }
            return totalAmount; 
        }

        public decimal GetVolume()
        {
            decimal totalVolume = 0;
            for(int i = 0; i < piggyBankList.Count; i++)
            {
                var volume = piggyBankList[i].Volume;
                var totalAmount = piggyBankList[i].Amount;
                decimal totalVol = totalAmount * volume;
                totalVolume += totalVol;
            };
            return totalVolume;
        }
       
        public void Reset()
        {
           piggyBankList.Clear();
        }
    }
}