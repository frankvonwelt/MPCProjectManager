using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "MPCVObject")]
    public class MPCVObjectProgram
    {
        [XmlElement(ElementName = "Version")]
        public Version Version { get; set; }
        [XmlElement(ElementName = "Program")]
        public Program Program { get; set; }
    }
}
