using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class PasswordVerifier
    {
        private List<Func<string, Tuple<bool, string>>> checks;

        public PasswordVerifier(params Func<string, Tuple<bool, string>>[] checks)
        {
            this.checks = new List<Func<string, Tuple<bool, string>>>(checks);
        }

        public static Tuple<bool, string> ValidateEmpty(string password)
        {
            if (password == string.Empty)
            {
                return Tuple.Create(false, $"{password} is empty");
            }
            else
            {
                return Tuple.Create(true, password);
            }
        }

        public static Tuple<bool, string> ValidateMinLength(string password)
        {
            if (password.Length <= 7)
            {
                return Tuple.Create(false, $"{password} length too short");
            }
            else
            {
                return Tuple.Create(true, password);
            }
        }

        public static Tuple<bool, string> ValidateMaxLength(string password)
        {
            if (password.Length >= 15)
            {
                return Tuple.Create(false, $"{password} length too long");
            }
            else
            {
                return Tuple.Create(true, password);
            }
        }

        public static Tuple<bool, string> ValidateLetter(string password)
        {
            if (!password.Any(char.IsLetter))
            {
                return Tuple.Create(false, $"{password} hasn't alphanumerical chars");
            }
            else
            {
                return Tuple.Create(true, password);
            }
        }

        public static Tuple<bool, string> ValidateDigit(string password)
        {
            if (!password.Any(char.IsNumber))
            {
                return Tuple.Create(false, $"{password} hasn't digits");
            }
            else
            {
                return Tuple.Create(true, password);
            }
        }

        public Tuple<bool, string> Verify(string password)
        {
            foreach (var check in checks)
            {
                var result = check(password);
                if (!result.Item1)
                {
                    return result;
                }
            }

            return Tuple.Create(true, password);
        }

        public void AddCheck(Func<string, Tuple<bool, string>> check)
        {
            checks.Add(check);
        }

        public bool RemoveCheck(Func<string, Tuple<bool, string>> check)
        {
            return checks.Remove(check);
        }
    }
}
