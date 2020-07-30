using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "ProgramMode")]
    public class ProgramMode
    {
        [XmlElement(ElementName = "QLink")]
        public List<QLink> QLink { get; set; }
    }
}
