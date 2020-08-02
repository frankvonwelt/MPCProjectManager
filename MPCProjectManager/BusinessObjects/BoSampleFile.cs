using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCProjectManager.BO
{
    public class BoSampleFile
    {
        public string SampleFileName { get; set; }
        public string SampleFileExtension { get; set; }
        public string SampleFile
        {
            get { return SampleFileName + "." + SampleFileExtension; }
        }
    }
}
