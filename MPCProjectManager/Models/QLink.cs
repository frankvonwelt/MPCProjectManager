using System;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class QLink
    {
        [XmlElement(ElementName = "Type")]
        public Type Type { get; set; }

        [XmlElement(ElementName = "Parameter")]
        public string Parameter { get; set; }

        [XmlElement(ElementName = "Momentary")]
        public string Momentary { get; set; }
        
        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }
        
        [XmlElement(ElementName = "Pad")]
        public string Pad { get; set; }
	}
}
