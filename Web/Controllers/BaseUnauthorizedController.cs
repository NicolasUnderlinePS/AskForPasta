using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Controllers
{
    public class BaseUnauthorizedController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //var credentials = WhiteLabelUtils.GetByContext(HttpContext);
                //_whiteLabelCredentials = credentials;

                //ViewData["CompanyId"] = credentials.CompanyId;
                //ViewData["Name"] = credentials.Name;
                //ViewData["SiteName"] = credentials.SiteName;
                //ViewData["ReducedName"] = credentials.ReducedName;
                //ViewData["InternetBankingUrl"] = credentials.InternetBankingUrl;
                //ViewData["FileIdentifier"] = credentials.FileIdentifier;
                //ViewData["LinkNewPassWord"] = credentials.LinkNewPassWord;
                //ViewData["WebsiteVersion"] = credentials.WebsiteVersion;
            }
            catch (Exception)
            {

            }
        }
    }
}
