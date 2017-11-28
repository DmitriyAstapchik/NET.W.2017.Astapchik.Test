using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class HtmlConverter : IDocumentConverter
    {
        public string Convert(BoldText bold)
        {
            return "<b>" + bold.Text + "</b>";
        }

        public string Convert(PlainText plain)
        {
            return plain.Text;
        }

        public string Convert(Hyperlink link)
        {
            return "<a href=\"" + link.Url + "\">" + link.Text + "</a>";
        }
    }
}
