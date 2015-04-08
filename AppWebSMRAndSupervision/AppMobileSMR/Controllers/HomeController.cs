using AppMobileSMR.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppMobileSMR.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> PostLocation(string latitute, string longitute)
        {
            var location = new LocationModels();
            location.Latitute = latitute;
            location.Longitude = longitute;
            location.Date = DateTime.Now;
            location.Email = User.Identity.Name;

            await WebApi.WebApiController.PostLocation(location);

            return View("Index");
        }
    }
}
