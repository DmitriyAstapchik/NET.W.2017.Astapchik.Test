using System;
using System.Collections.Generic;
using Task5.Solution;

namespace Task5.Solution
{
    public class Document : IFormattable
    {
        private List<DocumentPart> parts;

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }
            this.parts = new List<DocumentPart>(parts);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            string output = string.Empty;

            foreach (DocumentPart part in this.parts)
            {
                output += $"{part.ToString(format, formatProvider)}\n";
            }

            return output;
        }
    }
}
