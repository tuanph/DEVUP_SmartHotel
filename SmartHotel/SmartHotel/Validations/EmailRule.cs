using System.ComponentModel.DataAnnotations;

namespace SmartHotel.Validations
{
    public class EmailRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public EmailRule()
        {
            ValidationMessage = "Should be an email.";
        }
        public bool Check(T value)
        {
            return new EmailAddressAttribute().IsValid(value);
        }
    }
}

