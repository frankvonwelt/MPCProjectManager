using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "PadNote")]
    public class PadNote
    {
        [XmlElement(ElementName = "Note")]
        public string Note { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }
}
