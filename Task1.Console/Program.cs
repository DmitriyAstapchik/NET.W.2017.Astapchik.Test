using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution;

namespace Task1.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var verifier = new PasswordVerifier(
                PasswordVerifier.ValidateEmpty,
                PasswordVerifier.ValidateMinLength,
                PasswordVerifier.ValidateMaxLength,
                PasswordVerifier.ValidateLetter,
                PasswordVerifier.ValidateDigit);

            var service = new PasswordCheckerService(new SqlRepository(), verifier);

            System.Console.WriteLine(service.VerifyPassword("123aff3fe"));

            verifier.AddCheck(Program.ValidateCapital);
            System.Console.WriteLine(service.VerifyPassword("123aff3fe"));

            verifier.RemoveCheck(PasswordVerifier.ValidateMinLength);
            System.Console.WriteLine(service.VerifyPassword("2aD"));

            System.Console.Read();
        }

        private static Tuple<bool, string> ValidateCapital(string password)
        {
            if (!password.Any(c => char.IsUpper(c)))
            {
                return Tuple.Create(false, $"{password} has no capitals");
            }
            else
            {
                return Tuple.Create(true, (string)null);
            }
        }
    }
}
