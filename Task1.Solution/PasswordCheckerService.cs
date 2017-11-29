using System;
using System.Linq;

namespace Task1.Solution
{
    public class PasswordCheckerService
    {
        public IRepository Repository { get; set; }
        public PasswordVerifier Verifier { get; set; }

        public PasswordCheckerService(IRepository repository, PasswordVerifier verifier)
        {
            this.Repository = repository ?? throw new ArgumentNullException();
            this.Verifier = verifier ?? throw new ArgumentNullException();
        }

        public Tuple<bool, string> VerifyPassword(string password)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            var result = Verifier.Verify(password);
            if (!result.Item1)
            {
                return result;
            }

            Repository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
