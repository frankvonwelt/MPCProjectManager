using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "PadGroupMap")]
    public class PadGroupMap
    {
        [XmlElement(ElementName = "PadGroup")]
        public List<PadGroup> PadGroup { get; set; }
    }
}
