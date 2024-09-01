using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using HrProject.Domain.Entities;

namespace HrProject.Presentation.Attribitues
{
    public class AdminAuthorizeAttribute : TypeFilterAttribute
    {
        public AdminAuthorizeAttribute() : base(typeof(AdminAuthorizeFilter))
        {
        }

        private class AdminAuthorizeFilter : IAsyncActionFilter
        {
            private readonly UserManager<ApplicationUser> userManager;

            public AdminAuthorizeFilter(UserManager<ApplicationUser> userManager)
            {
                this.userManager = userManager;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var user = await userManager.GetUserAsync(context.HttpContext.User);
                if (user != null)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles.Contains("Full Admin"))
                    {
                        await next();
                        return;
                    }
                }

                // Kullanıcı Admin değilse, AccessDenied sayfasına yönlendir.
                context.Result = new RedirectResult("/Identity/Account/AccessDenied");
            }
        }
    }
}
