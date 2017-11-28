using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class Bank
    {
        private Stock stock;

        public string Name { get; set; }

        public Bank(string name, Stock stock)
        {
            this.Name = name;
            this.stock = stock;
            stock.NewMarket += Stock_NewMarket;
        }

        private void Stock_NewMarket(object sender, MarketEventArgs e)
        {
            StockInfo sInfo = e.Info;

            if (sInfo.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
        }
    }
}
