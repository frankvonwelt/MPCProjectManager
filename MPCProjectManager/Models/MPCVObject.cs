using System;
using System.IO;
using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "MPCVObject")]
    public class MPCVObject
    {
        [XmlElement(ElementName = "Version")]
        public System.Version Version { get; set; }
        [XmlElement(ElementName = "AllSeqSamps")]
        public AllSequencesAndSongs AllSequencesAndSongs { get; set; }

        [XmlElement(ElementName = "Program")]
        public Program Program { get; set; }
        public void SaveToFile(string path)
        {
            using (FileStream file = File.Open(path, FileMode.Create))
            {
                Save(file);
            }
        }
        private void Save(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(GetType());
            serializer.Serialize(stream, this);
        }
    }
}
