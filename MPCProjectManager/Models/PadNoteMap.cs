using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "PadNoteMap")]
    public class PadNoteMap
    {
        [XmlElement(ElementName = "PadNote")]
        public List<PadNote> PadNote { get; set; }
    }
}
