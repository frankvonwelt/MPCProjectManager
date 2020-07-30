using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class Locator
    {
        [XmlElement(ElementName = "LocatorBar")]
        public string LocatorBar { get; set; }
        [XmlElement(ElementName = "LocatorBeat")]
        public string LocatorBeat { get; set; }
        [XmlElement(ElementName = "LocatorPulse")]
        public string LocatorPulse { get; set; }
    }
}
