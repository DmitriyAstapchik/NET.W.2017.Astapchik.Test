using System;

namespace Task5.Solution
{
    public abstract class DocumentPart
    {
        public string Text { get; set; }

        public abstract string Convert(IDocumentConverter converter);

      //  public abstract string ToHtml();

       // public abstract string ToPlainText();

      //  public abstract string ToLaTeX();

        //public string ToString(string format, IFormatProvider formatProvider)
        //{
        //    return ((ICustomFormatter)formatProvider.GetFormat(typeof(Document))).Format(format, this, formatProvider);
        //}
    }
}
