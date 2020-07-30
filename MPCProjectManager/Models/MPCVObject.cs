using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "MPCVObject")]
    public class MPCVObject
    {
        [XmlElement(ElementName = "Version")]
        public System.Version Version { get; set; }
        [XmlElement(ElementName = "AllSeqSamps")]
        public AllSequencesAndSongs AllSequencesAndSongs { get; set; }
    }
}
