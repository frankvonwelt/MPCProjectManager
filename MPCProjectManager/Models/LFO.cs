using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "LFO")]
    public class LFO
    {
        [XmlAttribute(AttributeName = "LfoNum")]
        public int LfoNum { get; set; }
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Rate")]
        public string Rate { get; set; }
        [XmlElement(ElementName = "Sync")]
        public string Sync { get; set; }
        [XmlElement(ElementName = "Reset")]
        public string Reset { get; set; }
        [XmlElement(ElementName = "LfoPitch")]
        public float LfoPitch { get; set; }
        [XmlElement(ElementName = "LfoCutoff")]
        public float LfoCutoff { get; set; }
        [XmlElement(ElementName = "LfoVolume")]
        public float LfoVolume { get; set; }
        [XmlElement(ElementName = "LfoPan")]
        public float LfoPan { get; set; }
    }
}
