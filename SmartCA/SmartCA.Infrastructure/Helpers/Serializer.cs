using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Infrastructure.Helpers
{
    public static class Serializer
    {
        public static byte[] Serialize(object graph)
        {
            byte[] serializeData = null;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, graph);
                serializeData = stream.ToArray();
            }
            return serializeData;
        }

        public static object Deserialize(byte[] serializeData)
        {
            object graph = null;
            if (serializeData != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    for (int i = 0; i < serializeData.Length; i++)
                    {
                        stream.WriteByte(serializeData[i]);
                    }
                    stream.Position = 0;
                    BinaryFormatter formatter = new BinaryFormatter();
                    graph = formatter.Deserialize(stream);
                }
            }
            return graph;
        }
    }
}
