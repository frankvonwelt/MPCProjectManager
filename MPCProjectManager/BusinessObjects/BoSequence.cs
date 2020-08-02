using System.Collections.Generic;
using System.IO;

namespace MPCProjectManager.BO
{
    public class BoSequence
    {
        public string SequenceNumber { get; set; }
        public List<BoProgram> UsedBoPrograms { get; set; }
        public string SxqFileFullPath { get; set; }
        public Melanchall.DryWetMidi.Core.MidiFile SxqFile { get; set; }
        public BoSequence()
        {
            UsedBoPrograms = new List<BoProgram>();
        }

        public void ParsePrograms(List<BoProgram> proglist)
        {
            var fileAsciiContent = File.ReadAllText(SxqFileFullPath);
            foreach(BoProgram bop in proglist)
            {
                
                var namewoExtension = bop.ProgramName.Split('.')[0];
                if (fileAsciiContent.Contains(namewoExtension))
                {
                    UsedBoPrograms.Add(bop);
                }
            }
        }
    }
}
