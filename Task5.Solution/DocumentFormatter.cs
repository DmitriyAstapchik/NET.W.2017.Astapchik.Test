using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class DocumentFormatter : ICustomFormatter, IFormatProvider
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is DocumentPart part)
            {
                switch (format)
                {
                    case "html":
                        return part.ToHtml();
                    case "plain":
                        return part.ToPlainText();
                    case "latex":
                        return part.ToLaTeX();
                    default:
                        throw new FormatException();
                }
            }
            else
            {
                throw new FormatException();
            }
         
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(Document))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
