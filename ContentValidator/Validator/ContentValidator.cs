using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentValidator.Validator
{
    /// <summary>
    /// Class for content validator which handles validation rules
    /// </summary>
    public class ContentValidator : IContentValidator
    {
        private Dictionary<IContentValidationResult, Func<IContentValidationResult, bool>> _failedResults =
            new Dictionary<IContentValidationResult, Func<IContentValidationResult, bool>>();

        /// <summary>
        /// Validates content by defined rule
        /// </summary>
        public bool Validate<T>(T content, IContentValidationRule<T> rule)
        {
            var result = rule.Validate(content);
            if(!result.IsValid)
            {
                _failedResults.Add(result, rule.ResolveStrategy);
            }

            return _failedResults.Count == 0;
        }

        /// <summary>
        /// Validates content by multiple defined rules
        /// </summary>
        public bool Validate<T>(T content, IEnumerable<IContentValidationRule<T>> rules)
        {
            foreach(var rule in rules)
            {
                var result = rule.Validate(content);
                if(!result.IsValid)
                {
                    _failedResults.Add(result, rule.ResolveStrategy);
                }
            }

            return _failedResults.Count == 0;
        }

        /// <summary>Class1.cs
        /// Solve all the problems that have been found.
        /// </summary>
        public bool ResolveAllResults()
        {
            return ResolveResults(resilt => true);
        }

        /// <summary>
        /// Solve the problems that have been found and are marked as blocking.
        /// </summary>
        public bool ResolveBlockingResults()
        {
            return ResolveResults(result => result.IsBlocking);
        }

        /// <summary>
        /// Solve the problems that have been found and are not marked as blocking.
        /// </summary>
        public void ResolveNonBlockingResults()
        {
            ResolveResults(result => !result.IsBlocking);
        }

        /// <summary>
        /// Solves problems that have been found and match predicate
        /// </summary>
        private bool ResolveResults(Func<IContentValidationResult, bool> predicate)
        {
            if (!_failedResults.Any()) return true;

            var result = _failedResults.Keys.FirstOrDefault(predicate);
            while(result != null)
            {
                var strategy = _failedResults[result];
                if (!strategy(result))
                    return false;

                _failedResults.Remove(result);
                result = _failedResults.Keys.FirstOrDefault(predicate);
            }

            return true;
        }
    }
}
