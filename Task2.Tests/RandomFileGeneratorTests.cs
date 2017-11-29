using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Task2.Solution;

namespace Task2.Tests
{
    [TestFixture]
    public class RandomFileGeneratorTests
    {
        private static RandomFileGenerator gen = Mock.Of<RandomFileGenerator>(gen => gen.WorkingDirectory == "test directory");
        private Mock<RandomFileGenerator> genMock = Mock.Get(gen);

        [Test]
        public void GenerateFilesTest()
        {
            gen.GenerateFiles(1, 10);
            genMock.VerifyGet(gen => gen.FileExtension, Times.Exactly(1));
            genMock.VerifyGet(gen => gen.WorkingDirectory, Times.Between(2, 3, Range.Inclusive));
            genMock.ResetCalls();

            gen.GenerateFiles(2, 20);
            genMock.VerifyGet(gen => gen.FileExtension, Times.Exactly(2));
            genMock.VerifyGet(gen => gen.WorkingDirectory, Times.Between(4, 6, Range.Inclusive));
            genMock.ResetCalls();

            gen.GenerateFiles(10, 10);
            genMock.VerifyGet(gen => gen.FileExtension, Times.Exactly(10));
            genMock.VerifyGet(gen => gen.WorkingDirectory, Times.Between(20, 30, Range.Inclusive));
            genMock.ResetCalls();

            gen.GenerateFiles(0, 10);
            genMock.VerifyGet(gen => gen.FileExtension, Times.Never);
            genMock.VerifyGet(gen => gen.WorkingDirectory, Times.Never);
            genMock.ResetCalls();
        }
    }
}
