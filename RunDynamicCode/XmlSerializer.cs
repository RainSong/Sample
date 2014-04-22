using System;
using System.IO;
using System.Text;
using System.Xml;

namespace RunDynamicCode
{
    public static class Serializer
    {
        public static T Deserialize<T>(string xmlString, string encodingName)
        {
            var encding = Encoding.GetEncoding(encodingName);
            return Deserialize<T>(xmlString, encding);
        }

        public static T Deserialize<T>(string xmlString, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(xmlString))
                return default(T);


            T t = default(T);
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            byte[] bytes = encoding.GetBytes(xmlString);
            using (Stream xmlStream = new MemoryStream(bytes))
            {
                using (XmlReader xmlReader = XmlReader.Create(xmlStream))
                {
                    Object obj = xmlSerializer.Deserialize(xmlReader);
                    t = (T)obj;
                }
            }
            return t;
        }
    }
}
