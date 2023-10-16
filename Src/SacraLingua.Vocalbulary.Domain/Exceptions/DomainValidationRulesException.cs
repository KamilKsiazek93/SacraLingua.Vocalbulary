using System.ComponentModel.DataAnnotations;

namespace SacraLingua.Vocalbulary.Domain.Exceptions
{
    public class DomainValidationRulesException : Exception
    {
        public ICollection<string> ErrorMessages { get; }

        public DomainValidationRulesException(ICollection<ValidationResult> brokenRules, string message)
        : base(message)
        {
            ErrorMessages = brokenRules.Select(x => x.ErrorMessage).ToList();
        }

        public override string Message
        {
            get
            {
                if (ErrorMessages.Any())
                {
                    return $"{base.Message}{Environment.NewLine} {string.Join(Environment.NewLine, ErrorMessages)}{Environment.NewLine}";
                }
                return base.Message;
            }
        }
    }
}
