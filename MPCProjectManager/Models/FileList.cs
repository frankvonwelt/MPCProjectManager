using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class FileList
    {
        [XmlElement(ElementName = "File")]
        public List<string> File { get; set; }
    }
}
