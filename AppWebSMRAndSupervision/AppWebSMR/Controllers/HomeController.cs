using System.Web.Mvc;

namespace AppWebSMR.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Refresh()
        {
            var locations = WebApi.WebApiController.GetLocations();
            return View("Index");
        }
    }
}
