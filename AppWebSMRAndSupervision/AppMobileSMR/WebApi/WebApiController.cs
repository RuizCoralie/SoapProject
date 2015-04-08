using AppMobileSMR.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppMobileSMR.WebApi
{
    public class WebApiController
    {
        private static string _UrlWebAPi = System.Configuration.ConfigurationManager.AppSettings["ApiMobile"];

        public static async Task PostLocation(LocationModels location)
        {
            //WebClient wc = new WebClient();
            //string json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/utilisateur"));

            //users = JsonConvert.DeserializeObject<List<Utilisateur>>(json);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_UrlWebAPi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Envois des données
                HttpResponseMessage reponse = await client.PutAsJsonAsync<LocationModels>("api/Location", location);
                if (reponse.IsSuccessStatusCode) { Console.WriteLine("location : " + location); }
            }
        }
    }
}