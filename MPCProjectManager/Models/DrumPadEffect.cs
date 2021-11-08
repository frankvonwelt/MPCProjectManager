using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "DrumPadEffect")]
    public class DrumPadEffect
    {
        [XmlAttribute(AttributeName = "Num")]
        public int Num_DrumPadEffect { get; set; }
        [XmlAttribute(AttributeName = "Parameter")]
        public float Parameter_DrumPadEffect { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public int Type_DrumPadEffect { get; set; }
    }
}
