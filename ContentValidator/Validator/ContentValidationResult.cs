using System.Collections.Generic;

namespace ContentValidator.Validator
{
    /// <summary>
    /// Container class for the result on some rule specific validation
    /// </summary>
    public class ContentValidationResult : IContentValidationResult
    {
        /// <summary>
        /// Validation results without any problem.
        /// </summary>
        public static readonly ContentValidationResult NoProblem = new ContentValidationResult(false, string.Empty) { IsValid = true };

        /// <summary>
        /// Constructor
        /// </summary>
        public ContentValidationResult(bool blocking, string problem)
        {
            IsValid = false;
            IsBlocking = blocking;
            ProblemsDescriptions = string.IsNullOrWhiteSpace(problem) ? new List<string>() : new List<string> { problem };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ContentValidationResult(bool blocking, IEnumerable<string> problems)
        {
            IsValid = false;
            IsBlocking = blocking;
            ProblemsDescriptions = new List<string>(problems);
        }

        /// <summary>
        /// Indicates whether this problem blockes further exectution.
        /// </summary>
        public bool IsBlocking { get; private set; }

        /// <summary>
        /// Is Content valid
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// List with descriptions for the problems found.
        /// </summary>
        public IReadOnlyList<string> ProblemsDescriptions { get; private set; }
    }
}
