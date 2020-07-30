using System.Collections.Generic;
using System.IO;
using MPCProjectManager.Models;

namespace MPCProjectManager.BO
{
    public class BOProgram
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
        public MPCProjectImporter.MPCProgramTypes ProgramType { get; set; }
        public List<BoSampleFile> SampleFileNames { get; set; }
        public BOProgram()
        {
            SampleFileNames = new List<BoSampleFile>();
        }

    }
}
