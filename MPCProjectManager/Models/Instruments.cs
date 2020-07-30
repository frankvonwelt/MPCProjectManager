using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "Instruments")]
    public class Instruments
    {
        [XmlElement(ElementName = "Instrument")]
        public List<Instrument> Instrument { get; set; }
    }
}
