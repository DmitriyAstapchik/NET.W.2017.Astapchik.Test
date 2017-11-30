using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class NewMarketEventArgs : EventArgs
    {
        private StockInfo info;

        public NewMarketEventArgs(StockInfo info)
        {
            this.info = info;
        }

        public virtual StockInfo Info => info;
    }
}
