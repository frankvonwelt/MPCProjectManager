using System.Collections.Generic;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class Locators
    {
        [XmlElement(ElementName = "Locator")]
        public List<Locator> LocatorList { get; set; }
    }
}
