using System.Collections.Generic;
using System.IO;

namespace MPCProjectManager.BO
{
    public class BOSequence
    {
        public string SequenceNumber { get; set; }
        public List<BOProgram> UsedBoPrograms { get; set; }
        public string SxqFileFullPath { get; set; }
        public Melanchall.DryWetMidi.Core.MidiFile SxqFile { get; set; }
        public BOSequence()
        {
            UsedBoPrograms = new List<BOProgram>();
        }

        public void ParsePrograms(List<BOProgram> proglist)
        {
            var fileAsciiContent = File.ReadAllText(SxqFileFullPath);
            foreach(BOProgram bop in proglist)
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
