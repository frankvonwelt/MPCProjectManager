using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class Mixer
    {
        [XmlElement(ElementName = "Mixer.Input")]
        public List<MixerInput> MixerInput { get; set; }
        [XmlElement(ElementName = "Mixer.Return")]
        public List<MixerReturn> MixerReturn { get; set; }
        [XmlElement(ElementName = "Mixer.Submix")]
        public List<MixerSubmix> MixerSubmix { get; set; }
        [XmlElement(ElementName = "Mixer.Output")]
        public List<MixerOutput> MixerOutput { get; set; }
        [XmlElement(ElementName = "Mixer.XFader.Breakpoint")]
        public string MixerXFaderBreakpoint { get; set; }
        [XmlElement(ElementName = "Mixer.XFader.Curve")]
        public string MixerXFaderCurve { get; set; }
    }

}
