using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace TCore.UniversalApp.Helpers.Json
{
    public static class XmlConverter
    {
        /// <summary>
        /// Serialize object (DataContract serialization)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <returns></returns>
        public static string Serialize<T>(T serializableObject)
        {
            DataContractSerializer js = new DataContractSerializer(typeof(T));

            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, serializableObject);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);

            string xml = sr.ReadToEnd();

            sr.Dispose();
            msObj.Dispose();

            return xml;
        }

        /// <summary>
        /// Deserialize object (DataContract serialization)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return default(T);
            }
            else
            {
                using (StringReader reader = new StringReader(xml))
                {
                    using (XmlReader xmlReader = XmlReader.Create(reader))
                    {
                        var serializer = new DataContractSerializer(typeof(T));
                        T theObject = (T)serializer.ReadObject(xmlReader);
                        return theObject;
                    }
                }
            }
        }
    }
}
