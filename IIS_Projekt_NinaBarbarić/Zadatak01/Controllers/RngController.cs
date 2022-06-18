using Commons.Xml.Relaxng;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Zadatak01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RngController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] Game game)
        {
            string xml;

            XmlSerializer serializer = new XmlSerializer(typeof(Game));

            using (StringWriter textWriter = new Utf8StringWriter())
            {
                serializer.Serialize(textWriter, game);
                xml = textWriter.ToString();
            };

            try
            {
            string path = Path.GetFullPath("Schemas");
            XmlSchemaSet schema = new XmlSchemaSet();

            XmlReader xmlReaderRNG = new XmlTextReader(path + "\\Game.rng");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            xmlDocument.Save(path + "\\game.xml");
            XmlReader xmlReaderXML = XmlReader.Create(path + "\\game.xml");
            XmlReader rd = new RelaxngValidatingReader(xmlReaderXML, xmlReaderRNG);
            XDocument doc = XDocument.Load(rd);

                doc.Validate(schema, ValidationEventHandler);
            }
            catch (Exception e)
            {
                return "Invalid: " + (e.Message);
            }

            return xml;
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}
