using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Application.Behaviours.Validations
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions;
        public AllowedExtensionsAttribute(string[] extensions) : base("yüklemek istediğin görsel, jpg, jpeg, gif, png uzantılı olmalıdır")
        {
            this.extensions = extensions;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!extensions.Contains(extension.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
