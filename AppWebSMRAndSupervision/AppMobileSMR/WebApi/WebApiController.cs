using AppMobileSMR.Models;
using System.Net;

namespace AppMobileSMR.WebApi
{
    public class WebApiController
    {
        private static string _UrlWebAPi = System.Configuration.ConfigurationManager.AppSettings["ApiMobile"];

        public static void PostLocation(LocationModels location)
        {
            WebClient wc = new WebClient();
            string json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/utilisateur"));


            //users = JsonConvert.DeserializeObject<List<Utilisateur>>(json);
        }
    }
}