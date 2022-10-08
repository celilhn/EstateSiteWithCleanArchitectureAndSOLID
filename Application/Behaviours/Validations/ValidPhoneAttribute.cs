using Application.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Application.Behaviours.Validations
{
    public class ValidPhoneAttribute : ValidationAttribute
    {
        public ValidPhoneAttribute()
       : base("Geçerli bir telefon numarası girmelisiniz") { }

        public override bool IsValid(object value)
        {
            string phone = value as string;
            return AppUtilities.IsValidPhone(phone);
        }
    }
}
