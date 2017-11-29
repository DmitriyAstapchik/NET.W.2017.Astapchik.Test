using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Task1.Solution.Tests
{
    [TestFixture]
    public class PasswordCheckerServiceTests
    {
        static IRepository repo = Mock.Of<IRepository>();
        static PasswordVerifier verifier = new PasswordVerifier();
        PasswordCheckerService service = new PasswordCheckerService(repo, verifier);

        [Test]
        public void VerifyPasswordTest()
        {
            Assert.Throws<ArgumentNullException>(() => new PasswordCheckerService(null, verifier));
            Assert.Throws<ArgumentNullException>(() => new PasswordCheckerService(repo, null));
            Assert.Throws<ArgumentException>(() => service.VerifyPassword(null));

            verifier.AddCheck(PasswordVerifier.ValidateEmpty);
            Assert.AreEqual(Tuple.Create(false, " is empty"), service.VerifyPassword(""));

            verifier.AddCheck(PasswordVerifier.ValidateMinLength);
            Assert.AreEqual(Tuple.Create(false, "12345 length too short"), service.VerifyPassword("12345"));

            verifier.AddCheck(PasswordVerifier.ValidateMaxLength);
            Assert.AreEqual(Tuple.Create(false, "asdqwerte35vdfr length too long"), service.VerifyPassword("asdqwerte35vdfr"));

            verifier.AddCheck(PasswordVerifier.ValidateLetter);
            Assert.AreEqual(Tuple.Create(false, "15948702 hasn't alphanumerical chars"), service.VerifyPassword("15948702"));

            verifier.AddCheck(PasswordVerifier.ValidateDigit);
            Assert.AreEqual(Tuple.Create(false, "asdwerqw hasn't digits"), service.VerifyPassword("asdwerqw"));

            Assert.AreEqual(Tuple.Create(true, "Password is Ok. User was created"), service.VerifyPassword("asdwer534qw"));
            Mock.Get(repo).Verify(repo => repo.Create("asdwer534qw"));
        }
    }
}
