namespace Task5.Console
{
    using System;
    using System.Collections.Generic;
    using Task5.Solution;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<DocumentPart> parts = new List<DocumentPart>
                {
                    new PlainText { Text = "Some plain text" },
                    new Hyperlink { Text = "google.com", Url = "https://www.google.by/" },
                    new BoldText { Text = "Some bold text" }
                };

            Document document = new Document(parts);

            Console.WriteLine(document.Convert(new HtmlConverter()));

            Console.WriteLine(document.Convert(new PlainTextConverter()));

            Console.WriteLine(document.Convert(new LaTeXConverter()));

            Console.Read();
        }
    }
}
