using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "Insert")]
    public class Insert
    {
        [XmlElement(ElementName = "Is64Bits")]
        public string Is64Bits { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "DescriptiveName")]
        public string DescriptiveName { get; set; }
        [XmlElement(ElementName = "FormatName")]
        public string FormatName { get; set; }
        [XmlElement(ElementName = "Category")]
        public string Category { get; set; }
        [XmlElement(ElementName = "ManufacturerName")]
        public string ManufacturerName { get; set; }
        [XmlElement(ElementName = "FileOrID")]
        public string FileOrID { get; set; }
        [XmlElement(ElementName = "UID")]
        public string UID { get; set; }
        [XmlElement(ElementName = "IsInstrument")]
        public string IsInstrument { get; set; }
        [XmlElement(ElementName = "NumInput")]
        public string NumInput { get; set; }
        [XmlElement(ElementName = "NumOutput")]
        public string NumOutput { get; set; }
        [XmlElement(ElementName = "ProgramNumber")]
        public string ProgramNumber { get; set; }
        [XmlElement(ElementName = "Data")]
        public string Data { get; set; }
    }


}
