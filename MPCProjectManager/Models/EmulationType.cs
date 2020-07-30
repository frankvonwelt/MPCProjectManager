using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class EmulationType
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}
