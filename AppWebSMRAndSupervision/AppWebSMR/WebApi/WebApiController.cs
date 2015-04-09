using AppWebSMR.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace AppWebSMR.WebApi
{
    public class WebApiController
    {
        private static string _UrlWebAPi = System.Configuration.ConfigurationManager.AppSettings["ApiWeb"];

        public static IEnumerable<LocationModels> GetLocations()
        {
            var locations = new List<LocationModels>();
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/Location"));

                locations = JsonConvert.DeserializeObject<List<LocationModels>>(json);
            }

            return locations;
        }
    }
}