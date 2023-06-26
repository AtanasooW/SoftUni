using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.Utilities
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T),xmlRoot);

            StringReader reader = new StringReader(inputXml);
            T deserlizedDTOs = (T)xmlSerializer.Deserialize(reader);
            return deserlizedDTOs;
        }
        public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

            StringReader reader = new StringReader(inputXml);
            T[] deserlizedDTOs = (T[])xmlSerializer.Deserialize(reader);
            return deserlizedDTOs;
        }
        public string Serialize<T>(T obj, string rootName)
        {
            var sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            XmlSerializerNamespaces namespases = new XmlSerializerNamespaces();
            namespases.Add(string.Empty, string.Empty);
           

           using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj, namespases);
            return sb.ToString().Trim();
        }
        public string Serialize<T>(T[] obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot =
                new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
