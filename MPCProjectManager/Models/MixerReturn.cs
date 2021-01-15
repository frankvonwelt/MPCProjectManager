using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "Mixer.Return")]
    public class MixerReturn {
        [XmlElement(ElementName = "Program.Xfader.Route")]
        public string ProgramXfaderRoute { get; set; }
        [XmlElement(ElementName = "ProgramName")]
        public string ProgramName { get; set; }
        [XmlElement(ElementName = "AudioRoute")]
        public AudioRoute AudioRoute { get; set; }
        [XmlElement(ElementName = "Insert1")]
        public Insert Insert1 { get; set; }
        [XmlElement(ElementName = "InsertEnable1")]
        public string InsertEnable1 { get; set; }
        [XmlElement(ElementName = "Send1")]
        public string Send1 { get; set; }
        [XmlElement(ElementName = "Send2")]
        public string Send2 { get; set; }
        [XmlElement(ElementName = "Send3")]
        public string Send3 { get; set; }
        [XmlElement(ElementName = "Send4")]
        public string Send4 { get; set; }
        [XmlElement(ElementName = "Volume")]
        public string Volume { get; set; }
        [XmlElement(ElementName = "Mute")]
        public string Mute { get; set; }
        [XmlElement(ElementName = "Solo")]
        public string Solo { get; set; }
        [XmlElement(ElementName = "Pan")]
        public string Pan { get; set; }
        [XmlElement(ElementName = "AutomationFilter")]
        public string AutomationFilter { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }
}
