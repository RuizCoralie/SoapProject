using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using System.Web.Http;
using WebServiceWebSMR.Helper;
using WebServiceWebSMR.Models;

namespace WebServiceWebSMR.Controllers
{
    public class LocationController : ApiController
    {
        // GET: api/Location
        public IEnumerable<LocationModels> Get()
        {
            var locations = new List<LocationModels>();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var queueDeclareResponse = channel.QueueDeclare("task_queue", true, false, false, null);

                    channel.BasicQos(0, 1, false);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("task_queue", false, consumer);

                    for (int i = 0; i < queueDeclareResponse.MessageCount; i++)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        LocationModels location = SerialisationHelper.DeserialisationLocation(body);
                        locations.Add(location);

                        //Console.WriteLine(" [x] Received {0}", location);
                        channel.BasicAck(ea.DeliveryTag, false);
                    }

                }

            }
            return locations;
        }

        // GET: api/Location/5
        public LocationModels Get(int id)
        {
            return new LocationModels();
        }

        // POST: api/Location
        public void Post([FromBody]LocationModels value)
        {
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
