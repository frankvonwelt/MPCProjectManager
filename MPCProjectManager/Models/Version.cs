using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class Version
    {
        [XmlElement(ElementName = "File_Version")]
        public string File_Version { get; set; }
        [XmlElement(ElementName = "Application")]
        public string Application { get; set; }
        [XmlElement(ElementName = "Application_Version")]
        public string Application_Version { get; set; }
        [XmlElement(ElementName = "Platform")]
        public string Platform { get; set; }
    }
}
