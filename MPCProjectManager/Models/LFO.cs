using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "LFO")]
    public class LFO
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Rate")]
        public string Rate { get; set; }
        [XmlElement(ElementName = "Sync")]
        public string Sync { get; set; }
        [XmlElement(ElementName = "Reset")]
        public string Reset { get; set; }
    }
}
