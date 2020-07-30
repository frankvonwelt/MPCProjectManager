using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "AudioRoute")]
    public class AudioRoute
    {
        [XmlElement(ElementName = "AudioRoute")]
        public string AudioRouteReference { get; set; }
        [XmlElement(ElementName = "AudioRouteSubIndex")]
        public string AudioRouteSubIndex { get; set; }
        [XmlElement(ElementName = "AudioRouteChannelBitmap")]
        public string AudioRouteChannelBitmap { get; set; }
        [XmlElement(ElementName = "InsertsEnabled")]
        public string InsertsEnabled { get; set; }
    }
}
