using ContentValidator.Content;
using System;
using System.Collections.Generic;

namespace ContentValidator.Validator.Rules
{
    /// <summary>
    /// Validation rule for the User content class
    /// </summary>
    public class UserValidationRule : IContentValidationRule<User>
    {
        private Func<IContentValidationResult, bool> _resolveStrategy;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public UserValidationRule(Func<IContentValidationResult, bool> resolveStrategy)
        {
            _resolveStrategy = resolveStrategy;
        }

        /// <summary>
        /// Resolve strategy for the specific rule
        /// </summary>
        public Func<IContentValidationResult, bool> ResolveStrategy
        {
            get { return _resolveStrategy; }
        }

        /// <summary>
        /// Function that validates the content and returns IContentValidationResult
        /// </summary>
        public IContentValidationResult Validate(User content)
        {
            var problems = new List<string>();

            if (content.Name == "")
                problems.Add("Name of the user is empty");

            if (content.Surname == "")
                problems.Add("Surname of the user is empty");

            if (content.Email == "")
                problems.Add("Email of the user is empty");

            if (content.Age <= 0)
                problems.Add("Age of the user is not valid");

            return (problems.Count == 0) ? ContentValidationResult.NoProblem : new ContentValidationResult(false, problems);
        }
    }
}
