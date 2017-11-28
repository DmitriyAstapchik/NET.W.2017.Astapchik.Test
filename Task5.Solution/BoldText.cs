using System;

namespace Task5.Solution
{
    public class BoldText : DocumentPart
    {
        public override string Convert(IDocumentConverter converter)
        {
            return converter.Convert(this);
        }
    }
}