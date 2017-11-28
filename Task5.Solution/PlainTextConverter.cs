using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class PlainTextConverter : IDocumentConverter
    {
        public string Convert(BoldText bold)
        {
            return bold.Text;
        }

        public string Convert(PlainText plain)
        {
            return "**" + plain.Text + "**";
        }

        public string Convert(Hyperlink link)
        {
            return link.Text + " [" + link.Url + "]";
        }
    }
}
