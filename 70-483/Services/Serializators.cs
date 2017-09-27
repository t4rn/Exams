using Exam70_483.Definitions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;

namespace Exam70_483.Services
{
    public class Serializators
    {
        public static List<Rate> ReadFromXml(string xml)
        {
            List<Rate> rateCollection = new List<Rate>();
            using (XmlReader reader = XmlReader.Create(xml))
            {
                while (reader.ReadToFollowing("rate"))
                {
                    Rate rate = new Rate();
                    reader.MoveToFirstAttribute();
                    rate.Category = reader.Value;

                    reader.MoveToNextAttribute();
                    DateTime rateDate;
                    if (DateTime.TryParse(reader.Value, out rateDate))
                    {
                        rate.Date = rateDate;
                    }

                    reader.ReadToFollowing("value");
                    decimal value;
                    if (decimal.TryParse(reader.ReadElementContentAsString(), out value))
                    {
                        rate.Value = value;
                    }

                    rateCollection.Add(rate);
                }
            }

            return rateCollection;
        }

        public static string SerializeWithDataContractJson<T>(T obj)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream1 = new MemoryStream();
            ser.WriteObject(stream1, obj);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);

            return sr.ReadToEnd();
        }

        public static string SerializeWithDataContract<T>(T obj)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                ser.WriteObject(ms, obj);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public static void SerializeWithDataContractToFile<T>(T obj, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                DataContractSerializer dcSerializer = new DataContractSerializer(typeof(T));
                dcSerializer.WriteObject(fs, obj);
            }
        }

        public static void SerializeWithBinaryFormatter<T>(T obj, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
            }
        }

        public static string SerializeWithBinaryWriter<T>(T obj)
        {
            var memoryStream = new MemoryStream();
            var serializer = new DataContractSerializer(typeof(T));
            XmlDictionaryWriter binaryWriter = XmlDictionaryWriter.CreateBinaryWriter(memoryStream);
            serializer.WriteObject(binaryWriter, obj);
            binaryWriter.Flush();

            memoryStream.Position = 0;
            using (StreamReader sr = new StreamReader(memoryStream))
            {
                return sr.ReadToEnd();
            }
        }

        public static T DeserializeWithJavaScript<T>(string json)
        {
            var ser = new JavaScriptSerializer();
            return ser.Deserialize<T>(json);
        }

        public static T DeserializeWithDataContractJson<T>(string input)
        {
            T obj = default(T);
            DataContractJsonSerializer jsSerializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(input)))
            {
                obj = (T)jsSerializer.ReadObject(memoryStream);
            }

            return obj;
        }
    }
}
