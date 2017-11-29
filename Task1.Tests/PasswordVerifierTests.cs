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
    public class PasswordVerifierTests
    {
        static PasswordVerifier verifier;

        [TestCaseSource("VerifyTestCases")]
        public Tuple<bool, string> VerifyTest(PasswordVerifier verifier, string password)
        {
            return verifier.Verify(password);
        }

        public static IEnumerable<TestCaseData> VerifyTestCases
        {
            get
            {
                verifier = new PasswordVerifier();
                yield return new TestCaseData(verifier, "").Returns(Tuple.Create(true, ""));

                verifier = new PasswordVerifier(PasswordVerifier.ValidateEmpty);
                yield return new TestCaseData(verifier, "").Returns(Tuple.Create(false, " is empty"));
                yield return new TestCaseData(verifier, "asd").Returns(Tuple.Create(true, "asd"));

                verifier = new PasswordVerifier(PasswordVerifier.ValidateEmpty, PasswordVerifier.ValidateLetter);
                yield return new TestCaseData(verifier, "").Returns(Tuple.Create(false, " is empty"));
                yield return new TestCaseData(verifier, "234").Returns(Tuple.Create(false, "234 hasn't alphanumerical chars"));
                yield return new TestCaseData(verifier, "a").Returns(Tuple.Create(true, "a"));

                verifier = new PasswordVerifier(PasswordVerifier.ValidateMaxLength, PasswordVerifier.ValidateDigit, PasswordVerifier.ValidateMinLength);
                yield return new TestCaseData(verifier, "asd").Returns(Tuple.Create(false, "asd hasn't digits"));
                yield return new TestCaseData(verifier, "234").Returns(Tuple.Create(false, "234 length too short"));
                yield return new TestCaseData(verifier, "3463467775757575").Returns(Tuple.Create(false, "3463467775757575 length too long"));
                yield return new TestCaseData(verifier, "24353421").Returns(Tuple.Create(true, "24353421"));
            }
        }
    }
}
