using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebServiceMobileSMR.Helpers;
using WebServiceMobileSMR.Models;

namespace WebServiceMobileSMR.Controllers
{
    public class LocationController : ApiController
    {
        // GET: api/Location
        public IEnumerable<LocationModels> Get()
        {
            return new List<LocationModels>();
        }

        // GET: api/Location/5
        public LocationModels Get(int id)
        {
            return new LocationModels();
        }

        // POST: api/Location
        public void Post([FromBody]LocationModels value)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("task_queue", true, false, false, null);

                    var body = SerialisationHelper.SerialisationLocation(value);

                    var properties = channel.CreateBasicProperties();
                    properties.SetPersistent(true);

                    channel.BasicPublish("", "task_queue", properties, body);
                    Console.WriteLine(" [x] Sent {0}", value.ToString());
                }
            }
        }

        // PUT: api/Location/5
        public void Put(int id, [FromBody]LocationModels value)
        {
        }

        // DELETE: api/Location/5
        public void Delete(int id)
        {
        }
    }
}
