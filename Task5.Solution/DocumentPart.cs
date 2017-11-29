using System;

namespace Task5.Solution
{
    public abstract class DocumentPart
    {
        public string Text { get; set; }

        public abstract string Convert(IDocumentConverter converter);
    }
}
