using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
    [XmlRoot(ElementName = "Layer")]
	public class Layer
	{
		[XmlElement(ElementName = "Active")]
		public string Active { get; set; }
		[XmlElement(ElementName = "Volume")]
		public string Volume { get; set; }
		[XmlElement(ElementName = "Pan")]
		public string Pan { get; set; }
		[XmlElement(ElementName = "Pitch")]
		public string Pitch { get; set; }
		[XmlElement(ElementName = "TuneCoarse")]
		public string TuneCoarse { get; set; }
		[XmlElement(ElementName = "TuneFine")]
		public string TuneFine { get; set; }
		[XmlElement(ElementName = "VelStart")]
		public string VelStart { get; set; }
		[XmlElement(ElementName = "VelEnd")]
		public string VelEnd { get; set; }
		[XmlElement(ElementName = "SampleStart")]
		public string SampleStart { get; set; }
		[XmlElement(ElementName = "SampleEnd")]
		public string SampleEnd { get; set; }
		[XmlElement(ElementName = "Loop")]
		public string Loop { get; set; }
		[XmlElement(ElementName = "LoopStart")]
		public string LoopStart { get; set; }
		[XmlElement(ElementName = "LoopEnd")]
		public string LoopEnd { get; set; }
		[XmlElement(ElementName = "LoopTune")]
		public string LoopTune { get; set; }
		[XmlElement(ElementName = "Mute")]
		public string Mute { get; set; }
		[XmlElement(ElementName = "RootNote")]
		public string RootNote { get; set; }
		[XmlElement(ElementName = "KeyTrack")]
		public string KeyTrack { get; set; }
		[XmlElement(ElementName = "SampleName")]
		public string SampleName { get; set; }

        [XmlElement(ElementName = "PitchRandom")]
        public string PitchRandom { get; set; }
        [XmlElement(ElementName = "VolumeRandom")]
        public string VolumeRandom { get; set; }
        [XmlElement(ElementName = "PanRandom")]
        public string PanRandom { get; set; }
        [XmlElement(ElementName = "OffsetRandom")]
        public string OffsetRandom { get; set; }

		[XmlElement(ElementName = "SampleFile")]
		public string SampleFile { get; set; }
		[XmlElement(ElementName = "SliceIndex")]
		public string SliceIndex { get; set; }
		[XmlElement(ElementName = "Direction")]
		public string Direction { get; set; }
		[XmlElement(ElementName = "Offset")]
		public string Offset { get; set; }
		[XmlElement(ElementName = "SliceStart")]
		public string SliceStart { get; set; }
		[XmlElement(ElementName = "SliceEnd")]
		public string SliceEnd { get; set; }
		[XmlElement(ElementName = "SliceLoopStart")]
		public string SliceLoopStart { get; set; }
		[XmlElement(ElementName = "SliceLoop")]
		public string SliceLoop { get; set; }
        [XmlElement(ElementName = "SliceLoopCrossFadeLength")]
        public string SliceLoopCrossFadeLength { get; set; }
        [XmlElement(ElementName = "SliceTailPosition")]
        public string SliceTailPosition { get; set; }
        [XmlElement(ElementName = "SliceTailLength")]
        public string SliceTailLength { get; set; }
        [XmlAttribute(AttributeName = "number")]
		public string Number { get; set; }
	}
}
