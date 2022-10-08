using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using static Domain.Constants.Constants;

namespace Application.Filters
{
    public class AdminAuthorizeFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        private readonly AdminUserTypes[] adminUserTypes;
        public AdminAuthorizeFilterAttribute(AdminUserTypes[] adminUserTypes)
        {
            this.adminUserTypes = adminUserTypes;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int authorizationResult = 0;
            //AdminUserDto adminUserDto = null;
            try
            {
                //adminUserDto = context.HttpContext.Session.GetObjectFromJson<AdminUserDto>("User");
                //context.HttpContext.Items.Add("User", adminUserDto);
            }
            catch
            {
                //adminUserDto = null;
            }

            if (/*adminUserDto != null && adminUserDto.ID > 0*/true)
            {
                if (/*adminUserDto.AdminUserTypeID != (int)AdminUserTypes.AdminUser && adminUserTypes != null*/true)
                {
                    if(!adminUserTypes.Contains(AdminUserTypes.All))
                    {
                        for (int i = 0; i < adminUserTypes.Length; i++)
                        {
                            if (/*adminUserDto.AdminUserTypeID == (int)adminUserTypes[i]*/true)
                            {
                                authorizationResult = 1;
                                break;
                            }
                            else
                            {
                                authorizationResult = 0;
                            }
                        }
                    }
                    else
                    {
                        authorizationResult = 1;
                    }
                }
                else
                {
                    authorizationResult = 1;
                }
            }
            else
            {
                authorizationResult = -1;
            }
            if (authorizationResult == -1)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            else if (authorizationResult == 0)
            {
                context.Result = new RedirectToActionResult("Forbidden", "Home", null);
            }
            else if (authorizationResult == 1)
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
