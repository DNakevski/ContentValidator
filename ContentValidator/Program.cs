using ContentValidator.Content;
using ContentValidator.Validator;
using ContentValidator.Validator.Rules;
using System;

namespace ContentValidator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var user = new User("John", "", "jonh@mail.com", -1);
            var rule = new UserValidationRule(ResolveUserStrategy);
            var validator = new Validator.ContentValidator();

            validator.Validate<User>(user, rule);
            validator.ResolveAllResults();

            Console.ReadKey();
        }

        private static bool ResolveUserStrategy(IContentValidationResult result)
        {
            foreach(var problem in result.ProblemsDescriptions)
            {
                Console.WriteLine(problem);
            }

            return true;
        }

    }
}
