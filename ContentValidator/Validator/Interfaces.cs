using System;
using System.Collections.Generic;

namespace ContentValidator.Validator
{
    /// <summary>
    /// Interface for the content validator
    /// </summary>
    public interface IContentValidator
    {
        /// <summary>
        /// Validate content with defined rules.
        /// </summary>
        /// <returns>True if content is valid, false if some rule are failed.</returns>
        bool Validate<T>(T content, IEnumerable<IContentValidationRule<T>> rules);

        /// <summary>
        /// Validate content with defined rule.
        /// </summary>
        /// <returns>True if content is valid, false if some rule are failed.</returns>
        bool Validate<T>(T content, IContentValidationRule<T> rule);

        /// <summary>
        /// Solve all the problems that have been found.
        /// </summary>
        bool ResolveAllResults();

        /// <summary>
        /// Solve the problems that have been found and are marked as blocking.
        /// </summary>
        bool ResolveBlockingResults();

        /// <summary>
        /// Solve the problems that have been found and are not marked as blocking.
        /// </summary>
        void ResolveNonBlockingResults();
    }

    /// <summary>
    /// Interface for content validation rule
    /// </summary>
    public interface IContentValidationRule<in T>
    {
        /// <summary> 
        /// Strategy for solve problems. 
        /// If there was some changes of the content during resolution, 
        /// possible it will be good to revalidate content.
        /// Returns true if problems solved.
        /// </summary>
        Func<IContentValidationResult, bool> ResolveStrategy { get; }

        /// <summary>
        /// Check the content by defined rules.
        /// </summary>
        IContentValidationResult Validate(T content);
    }

    /// <summary>
    /// Interface for content validation result
    /// </summary>
    public interface IContentValidationResult
    {
        /// <summary> Is result valid </summary>
        bool IsValid { get; }

        /// <summary> Is the problem blocking future executions </summary>
        bool IsBlocking { get; }

        /// <summary> List of problems found during the validation </summary>
        IReadOnlyList<string> ProblemsDescriptions { get; }
    }
}
