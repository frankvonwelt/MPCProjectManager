using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    public class Project
    {
        [XmlElement(ElementName = "Version")]
        public Version Version { get; set; }
    
        [XmlElement(ElementName = "ProductCode")]
        public string ProductCode { get; set; }
        
        [XmlElement(ElementName = "BPM")]
        public float BPM { get; set; }
        
        [XmlElement(ElementName = "MasterVolume")]
        public float MasterVolume { get; set; }
        
        [XmlElement(ElementName = "FileList")]
        public FileList FileList { get; set; }
        
        [XmlElement(ElementName = "Mixer")]
        public Mixer Mixer { get; set; }
        
        [XmlElement(ElementName = "QLinkAssignments")]
        public QLinkAssignments QLinkAssignments { get; set; }
        
        [XmlElement(ElementName = "MidiLearnAssignments")]
        public string MidiLearnAssignments { get; set; }
        
        [XmlElement(ElementName = "EmulationType")]
        public EmulationType EmulationType { get; set; }
        
        [XmlElement(ElementName = "MasterTempo.Enabled")]
        public bool MasterTempoEnabled { get; set; }
        
        [XmlElement(ElementName = "MasterTempo.Value")]
        public float MasterTempoValue { get; set; }
        
        [XmlElement(ElementName = "Notes-Title")]
        public string NotesTitle { get; set; }
        
        [XmlElement(ElementName = "Notes-Artist")]
        public string NotesArtist { get; set; }
        
        [XmlElement(ElementName = "Notes-OriginalArtist")]
        public string NotesOriginalArtist { get; set; }
        
        [XmlElement(ElementName = "Notes-Album")]
        public string NotesAlbum { get; set; }
        
        [XmlElement(ElementName = "Notes-Year")]
        public string NotesYear { get; set; }
        
        [XmlElement(ElementName = "Notes-Genre")]
        public string NotesGenre { get; set; }
        
        [XmlElement(ElementName = "Notes-Copyright")]
        public string NotesCopyright { get; set; }
        
        [XmlElement(ElementName = "Notes")]
        public string Notes { get; set; }
        [XmlElement(ElementName = "Key")]
        public string Key { get; set; }
	}



    



}
