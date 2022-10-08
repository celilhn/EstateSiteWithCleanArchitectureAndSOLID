using System.ComponentModel.DataAnnotations;

namespace Application.Behaviours.Validations
{
    public class ValidPasswordAttribute : ValidationAttribute
    {
        public ValidPasswordAttribute()
      : base("Şifreniz en az 6 haneli içerisinde en az bir rakam, en az bir büyük harf, en az bir küçük harf içermelidir") { }

        public override bool IsValid(object value)
        {
            string password = value as string;
            int digits = 0;
            int uppers = 0;
            int lowers = 0;
            foreach (var ch in password)
            {
                if (char.IsDigit(ch)) digits++;
                if (char.IsUpper(ch)) uppers++;
                if (char.IsLower(ch)) lowers++;
            }
            if (password.Length < 6 || digits == 0 || uppers == 0 || lowers == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
