using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "PadGroup")]
    public class PadGroup
    {
        [XmlElement(ElementName = "Group")]
        public string Group { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }
}
