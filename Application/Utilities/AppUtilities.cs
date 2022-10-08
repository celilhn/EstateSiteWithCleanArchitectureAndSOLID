using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Application.Utilities
{
    public static class AppUtilities
    {
        private static IConfiguration _configuration;

        public static void AppUtilitiesConfigure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetConfigurationValue(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        public static string EncryptSHA256(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhone(string phone)
        {
            if (phone == null)
                return false;
            if (phone.Length != 10)
                return false;
            if ((phone.Substring(0, 1) != "5"))
                return false;

            try
            {
                Convert.ToInt64(phone);
            }
            catch 
            { 
                return false; 
            }
            return true;
        }

        public static bool ValidateBorusanPassword(string password)
        {
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

        public static bool ValidatePassword(string password)
        {
            int digits = 0;
            int uppers = 0;
            int lowers = 0;
            int symbols = 0;
            foreach (var ch in password)
            {
                if (char.IsDigit(ch)) digits++;
                if (char.IsUpper(ch)) uppers++;
                if (char.IsLower(ch)) lowers++;
                if (!char.IsDigit(ch) && !char.IsUpper(ch) && !char.IsLower(ch))
                    symbols++;
            }
            if (password.Length < 8 || digits == 0 || uppers == 0 || lowers == 0 || symbols == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
