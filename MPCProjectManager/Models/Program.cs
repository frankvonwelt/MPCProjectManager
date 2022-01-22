using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "Program")]
    public class Program
    {
        [XmlElement(ElementName = "ProgramName")]
        public string ProgramName { get; set; }
        [XmlElement(ElementName = "ProgramPads-v2.10")]
        public string ProgramPadsv210 { get; set; }
        [XmlElement(ElementName = "CueBusEnable")]
        public string CueBusEnable { get; set; }
        [XmlElement(ElementName = "inputSource")]
        public string inputSource { get; set; }
        [XmlElement(ElementName = "ProgramPads")]
        public string ProgramPads { get; set; }
        [XmlElement(ElementName = "AudioRoute")]
        public AudioRoute AudioRoute { get; set; }
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
        [XmlElement(ElementName = "Pitch")]
        public string Pitch { get; set; }
        [XmlElement(ElementName = "TuneCoarse")]
        public string TuneCoarse { get; set; }
        [XmlElement(ElementName = "TuneFine")]
        public string TuneFine { get; set; }
        [XmlElement(ElementName = "Mono")]
        public string Mono { get; set; }
        [XmlElement(ElementName = "Program_Polyphony")]
        public string Program_Polyphony { get; set; }
        [XmlElement(ElementName = "PortamentoTime")]
        public string PortamentoTime { get; set; }
        [XmlElement(ElementName = "PortamentoLegato")]
        public string PortamentoLegato { get; set; }
        [XmlElement(ElementName = "PortamentoQuantized")]
        public string PortamentoQuantized { get; set; }
        [XmlElement(ElementName = "Instruments")]
        public Instruments Instruments { get; set; }
        [XmlElement(ElementName = "PadNoteMap")]
        public PadNoteMap PadNoteMap { get; set; }
        [XmlElement(ElementName = "PadGroupMap")]
        public PadGroupMap PadGroupMap { get; set; }
        [XmlElement(ElementName = "QLinkAssignments")]
        public QLinkAssignments QLinkAssignments { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}
