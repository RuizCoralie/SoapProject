using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using WebServiceWebSMR.Models;

namespace WebServiceWebSMR.Helper
{
    public class SerialisationHelper
    {
        public static LocationModels DeserialisationLocation(byte[] byteArray)
        {
            using (var stream = new MemoryStream(byteArray))
            {
                var bf = new BinaryFormatter();
                return (LocationModels)bf.Deserialize(stream);
            }
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