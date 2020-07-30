using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class Song
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "TempoIgnore")]
        public string TempoIgnore { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }
}
