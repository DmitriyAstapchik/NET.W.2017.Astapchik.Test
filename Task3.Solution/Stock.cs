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

        public event EventHandler<MarketEventArgs> NewMarket;

        void OnNewMarket(MarketEventArgs e)
        {
            NewMarket?.Invoke(this, e);
        }

        public void Market()
        {
            Random rnd = new Random();
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);
            OnNewMarket(new MarketEventArgs(stocksInfo));
        }
    }

    public class MarketEventArgs
    {
        StockInfo info;
        public MarketEventArgs(StockInfo info)
        {
            this.info = info;
        }

        public StockInfo Info => info;
    }
}
