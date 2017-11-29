using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Bank : IObserver
    {
        private IObservable stock;
      
        public Bank(string name, IObservable observable)
        {
            this.Name = name;
            stock = observable;
            stock.Register(this);
        }

        public string Name { get; set; }

        public void Update(object info)
        {
            StockInfo stinfo = (StockInfo)info;

            if (stinfo.Euro > 40)
            {
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, stinfo.Euro);
            }
            else
            {
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, stinfo.Euro);
            }
        }
    }
}
