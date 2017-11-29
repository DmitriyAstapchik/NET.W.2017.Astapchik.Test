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

        public Bank(string name, Stock stock)
        {
            this.Name = name;
            this.stock = stock;
            stock.NewMarket += Stock_NewMarket;
        }

        public string Name { get; set; }

        private void Stock_NewMarket(object sender, NewMarketEventArgs e)
        {
            StockInfo info = e.Info;

            if (info.Euro > 40)
            {
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, info.Euro);
            }
            else
            {
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, info.Euro);
            }
        }
    }
}
