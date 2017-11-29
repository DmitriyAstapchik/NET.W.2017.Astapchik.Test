using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Solution;
using Moq;

namespace Task5.Tests
{
    [TestFixture]
    public class DocumentTests
    {
        const string BoldText = "bold";
        const string PlainText = "plain";
        const string Hyperlink = "link";
        const string BoldText2 = "BOLD";
        const string PlainText2 = "PLAIN";
        const string Hyperlink2 = "LINK";
        static DocumentPart bold = new BoldText();
        static DocumentPart plain = new PlainText();
        static DocumentPart link = new Hyperlink();
        static IDocumentConverter converter = Mock.Of<IDocumentConverter>(c => c.Convert(It.IsAny<BoldText>()) == BoldText && c.Convert(It.IsAny<PlainText>()) == PlainText && c.Convert(It.IsAny<Hyperlink>()) == Hyperlink);
       static  IDocumentConverter converter2 = Mock.Of<IDocumentConverter>(c => c.Convert(It.IsAny<BoldText>()) == BoldText2 && c.Convert(It.IsAny<PlainText>()) == PlainText2 && c.Convert(It.IsAny<Hyperlink>()) == Hyperlink2);

        [TestCaseSource("ConvertTestCases")]
        [TestCaseSource("ConvertTestCases2")]
        public string ConvertTest(Document doc, IDocumentConverter converter)
        {
            return doc.Convert(converter);
        }

        public static IEnumerable<TestCaseData> ConvertTestCases
        {
            get
            {
                yield return new TestCaseData(new Document(new[] { bold, plain, link }), converter).Returns(BoldText + Environment.NewLine + PlainText + Environment.NewLine + Hyperlink + Environment.NewLine);
                yield return new TestCaseData(new Document(new DocumentPart[] { }), converter).Returns(string.Empty);
                yield return new TestCaseData(new Document(new [] { plain, plain, bold}), converter).Returns(PlainText + Environment.NewLine + PlainText + Environment.NewLine + BoldText + Environment.NewLine);
                yield return new TestCaseData(new Document(new[] { link, plain, bold, bold, link }), converter).Returns(Hyperlink + Environment.NewLine + PlainText + Environment.NewLine + BoldText + Environment.NewLine + BoldText + Environment.NewLine + Hyperlink + Environment.NewLine);
                yield return new TestCaseData(new Document(new[] { plain, plain, plain, bold }), converter).Returns(PlainText + Environment.NewLine + PlainText + Environment.NewLine + PlainText + Environment.NewLine + BoldText + Environment.NewLine);
            }
        }

        public static IEnumerable<TestCaseData> ConvertTestCases2
        {
            get
            {
                yield return new TestCaseData(new Document(new[] { bold, plain, link }), converter2).Returns(BoldText2 + Environment.NewLine + PlainText2 + Environment.NewLine + Hyperlink2 + Environment.NewLine);
                yield return new TestCaseData(new Document(new DocumentPart[] { }), converter2).Returns(string.Empty);
                yield return new TestCaseData(new Document(new[] { plain, plain, bold }), converter2).Returns(PlainText2 + Environment.NewLine + PlainText2 + Environment.NewLine + BoldText2 + Environment.NewLine);
                yield return new TestCaseData(new Document(new[] { link, plain, bold, bold, link }), converter2).Returns(Hyperlink2 + Environment.NewLine + PlainText2 + Environment.NewLine + BoldText2 + Environment.NewLine + BoldText2 + Environment.NewLine + Hyperlink2 + Environment.NewLine);
                yield return new TestCaseData(new Document(new[] { plain, plain, plain, bold }), converter2).Returns(PlainText2 + Environment.NewLine + PlainText2 + Environment.NewLine + PlainText2 + Environment.NewLine + BoldText2 + Environment.NewLine);
            }
        }
    }
}
