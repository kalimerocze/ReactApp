using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ReactApp.Utilities.JsonXmlConverter
{
    public class Converter
    {
        public static string ConvertXmlToJson(string xml)
        {
            //z xml objektu vytvorime retezec xml objekt reprezentujici xml elementy
            XElement xmlElement = XElement.Parse(xml);
            //prevedeme xml na JSON
            return System.Text.Json.JsonSerializer.Serialize(xmlElement);
        }
        public static string ConvertJsonToXml(string json)
        {
            //prevedeme objekt na JObject
            JObject jsonObject = JObject.Parse(json);
            //root je nazev korenoveho elementu a prevedeme to na xml format
            XNode xmlNode = JsonConvert.DeserializeXNode(jsonObject.ToString(), "root");
            return xmlNode.ToString();
        }
    }
}
