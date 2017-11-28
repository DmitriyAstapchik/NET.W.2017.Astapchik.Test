namespace Task5.Solution
{
    public class PlainText : DocumentPart
    {
        public override string Convert(IDocumentConverter converter)
        {
            return converter.Convert(this);
        }
    }
}
