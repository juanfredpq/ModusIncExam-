using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using System.Xml;

namespace ModusInc.Util
{
    public class Util
    {
        public Util() { }

        public static string ConvertDatatableToXML(DataTable dt, int iteration)
        {
            MemoryStream str = new MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return GetXmlNodeListByName(xmlstr,iteration);
        }

        public static T Deserialize2<T>(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T serializedData;
                using (Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    serializedData = (T)serializer.Deserialize(stream);
                }
                return serializedData;
            }
            catch
            {
                throw;
            }
        }

        public static T Deserialize<T>(string xmlString)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("data_x0024_"));
                T serializedData;
                StringReader stringReader = new StringReader(xmlString);
                serializedData = (T)serializer.Deserialize(stringReader);
                return serializedData;
            }
            catch
            {
                throw;
            }
        }

        public static T DeserializeXMLFileToObject<T>(string XmlFilename)
        {
            T returnObject = default(T);
            if (string.IsNullOrEmpty(XmlFilename)) return default(T);

            try
            {
                StreamReader xmlStream = new StreamReader(XmlFilename);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {

            }
            return returnObject;
        }


        public static string GetXmlNodeListByName(string xmlString, int iteration)
        {
            string xmlNodeIteration = string.Empty;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString);
            XmlNodeList nodes = xml.GetElementsByTagName("data_x0024_");
            for (int i = 0; i < nodes.Count; i++)
            {
                if (i == iteration)
                {
                    xmlNodeIteration = nodes[i].InnerXml;
                    return xmlNodeIteration;
                }
            }
            return xmlNodeIteration;
        }
    }
}
