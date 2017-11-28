using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class Broker
    {
        private Stock stock;

        public string Name { get; set; }

        public Broker(string name, Stock stock)
        {
            this.Name = name;
            this.stock = stock;
            stock.NewMarket += Stock_NewMarket;
        }

        private void Stock_NewMarket(object sender, MarketEventArgs e)
        {
            StockInfo sInfo = e.Info;

            if (sInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
        }

        public void StopTrade()
        {
            stock.NewMarket -= Stock_NewMarket;
        }
    }
}
