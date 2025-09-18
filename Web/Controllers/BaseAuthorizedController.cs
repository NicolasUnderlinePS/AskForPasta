using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Controllers
{
    public class BaseAuthorizedController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }
}
