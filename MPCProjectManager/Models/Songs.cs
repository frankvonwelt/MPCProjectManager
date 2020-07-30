using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class Songs
    {
        [XmlElement(ElementName = "Count")]
        public string Count { get; set; }
        [XmlElement(ElementName = "Song")]
        public List<Song> SongList { get; set; }
    }
}
