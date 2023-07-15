using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreEgitim6584.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usersession = context.HttpContext.Session.GetString("deger");
            var usercookie = context.HttpContext.Request.Cookies["username"];
            if (usersession == null) // ekrana ulaşmak için kullanacağımız kontrol (kuki veya session) boşsa
            {
                context.Result = new RedirectResult("/MVC11Sessions?msg=AccessDenied"); // kullanıcıyı oturum açma sayfasına yönlendir
            }
            base.OnActionExecuting(context);
        }
    }
}
