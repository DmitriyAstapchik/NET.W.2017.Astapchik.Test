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

        public Broker(string name, Stock stock)
        {
            this.Name = name;
            this.stock = stock;
            stock.NewMarket += Stock_NewMarket;
        }

        public string Name { get; set; }

        public void StopTrade()
        {
            stock.NewMarket -= Stock_NewMarket;
        }

        private void Stock_NewMarket(object sender, NewMarketEventArgs e)
        {
            StockInfo info = e.Info;

            if (info.USD > 30)
            {
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, info.USD);
            }
            else
            {
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, info.USD);
            }
        }
    }
}
