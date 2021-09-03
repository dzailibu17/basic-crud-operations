using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Model.Attributes
{
    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = (string)value;
            bool passwordstrong = CheckStrenght(password);
            if (!passwordstrong)
            {
                return new ValidationResult("Password is not valid!");
            }

            return ValidationResult.Success;
        }

        private bool CheckStrenght(string password)
        {
            if (password.Length >= 6 &&
                password.Any(char.IsUpper) &&
                password.Any(char.IsLower) &&
                password.Any(char.IsDigit))
            {
                return true;

            }
            return false;
        }
    }
}
