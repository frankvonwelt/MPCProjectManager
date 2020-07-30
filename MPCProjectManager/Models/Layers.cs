using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "Layers")]
    public class Layers
    {
        [XmlElement(ElementName = "Layer")]
        public List<Layer> Layer { get; set; }
    }
}
