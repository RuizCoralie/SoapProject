using AppWebSMR.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AppWebSMR.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index(IEnumerable<LocationModels> locations = null)
        {
            return View(locations);
        }

        public ActionResult Refresh()
        {
            var locations = WebApi.WebApiController.GetLocations();
            return View("Index", locations);
        }
    }
}
