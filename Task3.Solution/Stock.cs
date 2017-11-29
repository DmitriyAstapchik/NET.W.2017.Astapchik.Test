using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class Stock
    {
        private StockInfo stocksInfo;

        public Stock()
        {
            stocksInfo = new StockInfo();
        }

        public event EventHandler<NewMarketEventArgs> NewMarket;

        public void Market()
        {
            Random rnd = new Random();
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);
            NewMarket?.Invoke(this, new NewMarketEventArgs(stocksInfo));
        }
    }
}
