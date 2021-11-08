using System.Xml.Serialization;

namespace MPCProjectManager.Models
{
	[XmlRoot(ElementName = "Instrument")]
	public class Instrument
	{
		[XmlElement(ElementName = "AudioRoute")]
		public AudioRoute AudioRoute { get; set; }
		[XmlElement(ElementName = "Send1")]
		public string Send1 { get; set; }
		[XmlElement(ElementName = "Send2")]
		public string Send2 { get; set; }
		[XmlElement(ElementName = "Send3")]
		public string Send3 { get; set; }
		[XmlElement(ElementName = "Send4")]
		public string Send4 { get; set; }
		[XmlElement(ElementName = "Volume")]
		public string Volume { get; set; }
		[XmlElement(ElementName = "Mute")]
		public string Mute { get; set; }
		[XmlElement(ElementName = "Solo")]
		public string Solo { get; set; }
		[XmlElement(ElementName = "Pan")]
		public string Pan { get; set; }
		[XmlElement(ElementName = "AutomationFilter")]
		public string AutomationFilter { get; set; }
        [XmlElement(ElementName = "LfoPitch")]
		public string LfoPitch { get; set; }
		[XmlElement(ElementName = "LfoCutoff")]
		public string LfoCutoff { get; set; }
		[XmlElement(ElementName = "LfoVolume")]
		public string LfoVolume { get; set; }
		[XmlElement(ElementName = "LfoPan")]
		public string LfoPan { get; set; }
		[XmlElement(ElementName = "OneShot")]
		public string OneShot { get; set; }
		[XmlElement(ElementName = "FilterType")]
		public string FilterType { get; set; }
		[XmlElement(ElementName = "Cutoff")]
		public string Cutoff { get; set; }
		[XmlElement(ElementName = "Resonance")]
		public string Resonance { get; set; }
		[XmlElement(ElementName = "FilterEnvAmt")]
		public string FilterEnvAmt { get; set; }
		[XmlElement(ElementName = "AfterTouchToFilter")]
		public string AfterTouchToFilter { get; set; }
		[XmlElement(ElementName = "VelocityToStart")]
		public string VelocityToStart { get; set; }
		[XmlElement(ElementName = "VelocityToFilterAttack")]
		public string VelocityToFilterAttack { get; set; }
		[XmlElement(ElementName = "VelocityToFilter")]
		public string VelocityToFilter { get; set; }
		[XmlElement(ElementName = "VelocityToFilterEnvelope")]
		public string VelocityToFilterEnvelope { get; set; }
		[XmlElement(ElementName = "FilterAttack")]
		public string FilterAttack { get; set; }
		[XmlElement(ElementName = "FilterDecay")]
		public string FilterDecay { get; set; }
		[XmlElement(ElementName = "FilterSustain")]
		public string FilterSustain { get; set; }
		[XmlElement(ElementName = "FilterRelease")]
		public string FilterRelease { get; set; }
        [XmlElement(ElementName = "FilterAttackCurve")]
		public string FilterAttackCurve { get; set; }
        [XmlElement(ElementName = "FilterDecayCurve")]
		public string FilterDecayCurve { get; set; }
        [XmlElement(ElementName = "FilterReleaseCurve")]
		public string FilterReleaseCurve { get; set; }
		[XmlElement(ElementName = "FilterHold")]
		public string FilterHold { get; set; }
		[XmlElement(ElementName = "FilterDecayType")]
		public string FilterDecayType { get; set; }
		[XmlElement(ElementName = "FilterADEnvelope")]
		public string FilterADEnvelope { get; set; }
		[XmlElement(ElementName = "VolumeHold")]
		public string VolumeHold { get; set; }
		[XmlElement(ElementName = "VolumeDecayType")]
		public string VolumeDecayType { get; set; }
		[XmlElement(ElementName = "VolumeADEnvelope")]
		public string VolumeADEnvelope { get; set; }
		[XmlElement(ElementName = "VolumeAttack")]
		public string VolumeAttack { get; set; }
		[XmlElement(ElementName = "VolumeDecay")]
		public string VolumeDecay { get; set; }
		[XmlElement(ElementName = "VolumeSustain")]
		public string VolumeSustain { get; set; }
		[XmlElement(ElementName = "VolumeRelease")]
		public string VolumeRelease { get; set; }
        [XmlElement(ElementName = "VolumeAttackCurve")]
		public string VolumeAttackCurve { get; set; }
        [XmlElement(ElementName = "VolumeDecayCurve")]
        public string VolumeDecayCurve { get; set; }
        [XmlElement(ElementName = "VolumeReleaseCurve")]
		public string VolumeReleaseCurve { get; set; }
        [XmlElement(ElementName = "PitchHold")]
        public string PitchHold { get; set; }
        [XmlElement(ElementName = "PitchDecayType")]
        public string PitchDecayType { get; set; }
        [XmlElement(ElementName = "PitchADEnvelope")]
        public string PitchADEnvelope { get; set; }
        [XmlElement(ElementName = "PitchAttack")]
        public string PitchAttack { get; set; }
        [XmlElement(ElementName = "PitchDecay")]
        public string PitchDecay { get; set; }
        [XmlElement(ElementName = "PitchSustain")]
        public string PitchSustain { get; set; }
        [XmlElement(ElementName = "PitchRelease")]
        public string PitchRelease { get; set; }
        [XmlElement(ElementName = "PitchAttackCurve")]
        public string PitchAttackCurve { get; set; }
        [XmlElement(ElementName = "PitchDecayCurve")]
        public string PitchDecayCurve { get; set; }
        [XmlElement(ElementName = "PitchReleaseCurve")]
        public string PitchReleaseCurve { get; set; }
        [XmlElement(ElementName = "PitchEnvAmount")]
        public string PitchEnvAmount { get; set; }
        [XmlElement(ElementName = "VelocityToPitch")]
		public string VelocityToPitch { get; set; }
		[XmlElement(ElementName = "VelocityToVolumeAttack")]
		public string VelocityToVolumeAttack { get; set; }
		[XmlElement(ElementName = "VelocitySensitivity")]
		public string VelocitySensitivity { get; set; }
		[XmlElement(ElementName = "VelocityToPan")]
		public string VelocityToPan { get; set; }
        [XmlElement(ElementName = "RandomizationScale")]
        public string RandomizationScale { get; set; }
        [XmlElement(ElementName = "AttackRandom")]
        public string AttackRandom { get; set; }
        [XmlElement(ElementName = "DecayRandom")]
        public string DecayRandom { get; set; }
        [XmlElement(ElementName = "CutoffRandom")]
        public string CutoffRandom { get; set; }
        [XmlElement(ElementName = "ResonanceRandom")]
        public string ResonanceRandom { get; set; }
        [XmlElement(ElementName = "LFO")]
		public LFO LFO { get; set; }

        [XmlElement(ElementName = "DrumPadEffects")]
        public DrumPadEffects DrumPadEffects { get; set; }
        [XmlElement(ElementName = "TuneCoarse")]
        public string TuneCoarse { get; set; }
        [XmlElement(ElementName = "TuneFine")]
        public string TuneFine { get; set; }
        [XmlElement(ElementName = "Mono")]
        public string Mono { get; set; }
        [XmlElement(ElementName = "Polyphony")]
        public string Polyphony { get; set; }
        [XmlElement(ElementName = "FilterKeytrack")]
        public string FilterKeytrack { get; set; }
        [XmlElement(ElementName = "LowNote")]
        public string LowNote { get; set; }
        [XmlElement(ElementName = "HighNote")]
        public string HighNote { get; set; }
        [XmlElement(ElementName = "IgnoreBaseNote")]
        public string IgnoreBaseNote { get; set; }
        [XmlElement(ElementName = "ZonePlay")]
        public string ZonePlay { get; set; }
        [XmlElement(ElementName = "MuteGroup")]
        public string MuteGroup { get; set; }
        [XmlElement(ElementName = "MuteTarget1")]
        public string MuteTarget1 { get; set; }
        [XmlElement(ElementName = "MuteTarget2")]
        public string MuteTarget2 { get; set; }
        [XmlElement(ElementName = "MuteTarget3")]
        public string MuteTarget3 { get; set; }
        [XmlElement(ElementName = "MuteTarget4")]
        public string MuteTarget4 { get; set; }
        [XmlElement(ElementName = "SimultTarget1")]
        public string SimultTarget1 { get; set; }
        [XmlElement(ElementName = "SimultTarget2")]
        public string SimultTarget2 { get; set; }
        [XmlElement(ElementName = "SimultTarget3")]
        public string SimultTarget3 { get; set; }
        [XmlElement(ElementName = "SimultTarget4")]
        public string SimultTarget4 { get; set; }
        [XmlElement(ElementName = "TriggerMode")]
        public string TriggerMode { get; set; }
        [XmlElement(ElementName = "WarpTempo")]
		public string WarpTempo { get; set; }
		[XmlElement(ElementName = "BpmLock")]
		public string BpmLock { get; set; }
		[XmlElement(ElementName = "WarpEnable")]
		public string WarpEnable { get; set; }
		[XmlElement(ElementName = "StretchPercentage")]
		public string StretchPercentage { get; set; }
		[XmlElement(ElementName = "Layers")]
		public Layers Layers { get; set; }
		[XmlAttribute(AttributeName = "number")]
		public string Number { get; set; }
	}

}
