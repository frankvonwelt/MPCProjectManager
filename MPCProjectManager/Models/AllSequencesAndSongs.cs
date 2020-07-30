using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "AllSeqSamps")]
    public class AllSequencesAndSongs
    {
        [XmlElement(ElementName = "Sequences")]
        public Sequences Sequences { get; set; }

        [XmlElement(ElementName = "Songs")]
        public Songs Songs { get; set; }

        [XmlElement(ElementName = "Locators")] 
        public Locators Locators { get; set; }
    }
}




