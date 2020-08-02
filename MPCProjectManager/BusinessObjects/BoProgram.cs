using System.Collections.Generic;
using System.IO;
using MPCProjectManager.Models;

namespace MPCProjectManager.BO
{
    public class BoProgram
    {
        public string ProgramFullPath { get; set; }
        public string ProgramName
        {
            get { return Path.GetFileNameWithoutExtension(ProgramFullPath); }
        }

        public string ProgramFileName
        {
            get { return Path.GetFileName(ProgramFullPath); }
        }
        public MPCVObjectProgram MpcvObjectProgram { get; set; }
        public MPCProgramTypes ProgramType { get; set; }
        public List<BoSampleFile> SampleFileNames { get; set; }
        public BoProgram()
        {
            SampleFileNames = new List<BoSampleFile>();
        }

    }
}
