using System;
using System.Collections.Generic;
using Task5.Solution;

namespace Task5.Solution
{
    public class Document
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

        public string Convert(IDocumentConverter converter)
        {
            string result = string.Empty;
            foreach (var part in parts)
            {
                result += part.Convert(converter) + Environment.NewLine;
            }
            return result;
        }
    }
}
