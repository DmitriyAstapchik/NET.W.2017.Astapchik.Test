namespace Task5.Console
{
    using System.Collections.Generic;
    using System;
   // using Task5;
    using Task5.Solution;

    class Program
    {
        static void Main(string[] args)
        {
            List<DocumentPart> parts = new List<DocumentPart>
                {
                    new PlainText {Text = "Some plain text"},
                    new Hyperlink {Text = "google.com", Url = "https://www.google.by/"},
                    new BoldText {Text = "Some bold text"}
                };

            Document document = new Document(parts);
            var provider = new DocumentFormatter();

            Console.WriteLine(document.ToString("html", provider));

            Console.WriteLine(document.ToString("plain", provider));

            Console.WriteLine(document.ToString("latex", provider));

            Console.Read();
        }
    }
}
