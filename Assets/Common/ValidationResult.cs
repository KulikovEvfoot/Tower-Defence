namespace Common
{
    public class ValidationResult
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; }

        public static ValidationResult Success()
        {
            return new ValidationResult(true);
        }
        
        public static ValidationResult Fail(string errorMessage)
        {
            return new ValidationResult(errorMessage);
        }
        
        private ValidationResult(bool isValid, string errorMessage = null)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        private ValidationResult(string errorMessage)
        {
            IsValid = false;
            ErrorMessage = errorMessage;
        }
    }
}