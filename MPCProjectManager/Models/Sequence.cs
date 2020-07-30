using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "Sequence")]
    public class Sequence
    {
        [XmlElement(ElementName = "Active")]
        public string Active { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }
}
