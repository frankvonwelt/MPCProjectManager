using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class QLinkAssignments
    {
        [XmlElement(ElementName = "CurrentMode")]
        public string CurrentMode { get; set; }
        
        [XmlElement(ElementName = "ProjectMode")]
        public List<QLink> ProjectMode { get; set; }

        [XmlElement(ElementName = "PadParameterMode")]
        public List<QLink> PadParameterMode { get; set; }
	}
}