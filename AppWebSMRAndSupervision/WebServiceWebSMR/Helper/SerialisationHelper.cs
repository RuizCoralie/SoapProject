using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using WebServiceWebSMR.Models;

namespace WebServiceWebSMR.Helper
{
    public class SerialisationHelper
    {
        public static LocationModels DeserialisationLocation(byte[] byteArray)
        {
            var location = new LocationModels();
            using (var stream = new MemoryStream(byteArray))
            {
                var bf = new BinaryFormatter();
                try
                {
                    location = (LocationModels)bf.Deserialize(stream);
                }
                catch (System.Exception ex)
                {

                    throw ex;
                }
            }
            return location;
        }

        public static byte[] SerialisationLocation(LocationModels location)
        {
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, location);
                return ms.GetBuffer();
            }
        }
    }
}