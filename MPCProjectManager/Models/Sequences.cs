using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "Sequences")]
    public class Sequences
    {
        [XmlElement(ElementName = "Count")]
        public string Count { get; set; }
        [XmlElement(ElementName = "Sequence")]
        public List<Sequence> SequenceList { get; set; }
    }
}
