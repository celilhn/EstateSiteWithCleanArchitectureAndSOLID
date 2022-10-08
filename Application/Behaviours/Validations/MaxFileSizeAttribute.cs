using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Behaviours.Validations
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize) : base("Fotoğraf boyutu 2 MB'ı geçmemelidir.") 
        {
            this.maxFileSize = maxFileSize;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file != null && file.Length > maxFileSize)
            {
                return false;
            }
            return true;
        }
    }
}
