using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class MMixerItem
    {
        //[XmlElement(ElementName = "Xfader.Position")]
        //public string XfaderPosition { get; set; }

        [XmlElement(ElementName = "Xfader.Route")]
        public string XfaderRoute { get; set; }

        [XmlElement(ElementName = "Xfader.Curve")]
        public string XfaderCurve { get; set; }

        [XmlElement(ElementName = "ProgramName")]
        public string ProgramName { get; set; }

        [XmlElement(ElementName = "AudioRoute")]
        public AudioRoute AudioRoute { get; set; }

        [XmlElement(ElementName = "Insert1")]
        public Insert Insert1 { get; set; }
        
        [XmlElement(ElementName = "InsertEnable1")]
        public string InsertEnable1 { get; set; }

        [XmlElement(ElementName = "Insert2")]
        public Insert Insert2 { get; set; }

        [XmlElement(ElementName = "InsertEnable2")]
        public string InsertEnable2 { get; set; }

        [XmlElement(ElementName = "Insert3")]
        public Insert Insert3 { get; set; }

        [XmlElement(ElementName = "InsertEnable3")]
        public string InsertEnable3 { get; set; }

        [XmlElement(ElementName = "Insert4")]
        public Insert Insert4 { get; set; }

        [XmlElement(ElementName = "InsertEnable4")]
        public string InsertEnable4 { get; set; }

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

