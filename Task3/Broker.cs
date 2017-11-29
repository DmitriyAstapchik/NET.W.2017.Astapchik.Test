using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Broker : IObserver
    {
        private IObservable stock;

        public Broker(string name, IObservable observable)
        {
            this.Name = name;
            stock = observable;
            stock.Register(this);
        }

        public string Name { get; set; }

        public void Update(object info)
        {
            StockInfo stinfo = (StockInfo)info;

            if (stinfo.USD > 30)
            {
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, stinfo.USD);
            }
            else
            {
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, stinfo.USD);
            }
        }

        public void StopTrade()
        {
            stock.Unregister(this);
            stock = null;
        }
    }
}
