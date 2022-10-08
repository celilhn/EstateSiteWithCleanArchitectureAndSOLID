using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Application.Filters
{
    public class AdminAuthorizeAttribute : TypeFilterAttribute
    {
        public AdminAuthorizeAttribute(params AdminUserTypes[] adminUserTypes) : base(typeof(AdminAuthorizeFilterAttribute))
        {
            Arguments = new[] { adminUserTypes };
        }
    }
}
