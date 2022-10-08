using Application.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Application.Behaviours.Validations
{
    public class ValidMailAttribute : ValidationAttribute
    {
        public ValidMailAttribute()
       : base("Geçerli bir e-posta adresi girmelisiniz") { }

        public override bool IsValid(object value)
        {
            string mail = value as string;
            return AppUtilities.IsValidEmail(mail);
        }
    }
}
