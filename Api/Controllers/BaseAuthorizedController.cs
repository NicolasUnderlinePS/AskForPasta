using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Controllers
{
    public class BaseAuthorizedController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }
}
