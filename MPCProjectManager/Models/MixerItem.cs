using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class MixerItem
    {
        [XmlElement(ElementName = "Xfader.Position")]
        public string XfaderPosition { get; set; }

        [XmlElement(ElementName = "Xfader.Curve")]
        public string XfaderCurve { get; set; }

        [XmlElement(ElementName = "ProgramName")]
        public string ProgramName { get; set; }

        [XmlElement(ElementName = "AudioRoute")]
        public AudioRoute AudioRoute { get; set; }

        [XmlElement(ElementName = "Send1")]
        public float Send1 { get; set; }

        [XmlElement(ElementName = "Send2")]
        public float Send2 { get; set; }

        [XmlElement(ElementName = "Send3")]
        public float Send3 { get; set; }

        [XmlElement(ElementName = "Send4")]
        public float Send4 { get; set; }

        [XmlElement(ElementName = "Volume")]
        public float Volume { get; set; }

        [XmlElement(ElementName = "Mute")]
        public string Mute { get; set; }
        
        [XmlElement(ElementName = "Solo")]
        public string Solo { get; set; }

        [XmlElement(ElementName = "Pan")]
        public float Pan { get; set; }

        [XmlElement(ElementName = "AutomationFilter")]
        public int AutomationFilter { get; set; }

        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
	}
}

