using System;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;

namespace Adapter
{
    public class XMLDataReader
    {
        public string GetData()
        {
            return "<data><item>Value</item></data>";
        }
    }

    public interface IDataProvider
    {
        string GetData();
    }

    public class XmlToJson : IDataProvider
    {
        private readonly XMLDataReader _reader;
        public XmlToJson(XMLDataReader reader)
        {
            _reader = reader;
        }
        public string GetData()
        {
            string xmlData = _reader.GetData();
            var xml = XElement.Parse(xmlData);
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeXNode(xml, Newtonsoft.Json.Formatting.None, true);
            return jsonData;
        }
    }

    public class XmlToText : IDataProvider
    {
        private readonly XMLDataReader _reader;

        public XmlToText(XMLDataReader reader)
        {
            _reader = reader;   
        }

        public string GetData() {
            string xmlData = _reader.GetData();
            var xml = XElement.Parse(xmlData);
            string textData = xml.Value; 
            return textData;
        }
    }

    public class DataClient
    {
        private readonly IDataProvider _provider;
        public DataClient(IDataProvider provider) {
            _provider = provider;
        }

        public void DisplayData() { 
            var data = _provider.GetData();
            Console.Write(data);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            XMLDataReader reader = new XMLDataReader(); 
            IDataProvider toJson = new XmlToJson(reader);
            DataClient json = new DataClient(toJson);
            json.DisplayData();
            Console.WriteLine();
            IDataProvider toText = new XmlToText(reader);   
            DataClient text = new DataClient(toText);   
            text.DisplayData();
        }
    }
}