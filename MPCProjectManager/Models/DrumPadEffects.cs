using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "DrumPadEffects")]
    public class DrumPadEffects
    {
        [XmlElement(ElementName = "DrumPadEffect")]
        public List<DrumPadEffect> DrumPadEffect { get; set; }
    }
}
