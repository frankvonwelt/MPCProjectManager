using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCProjectManager.BusinessObjects
{
    public class CopyJob
    {
        public string SourceFullPath { get; set; }
        public string DestinationFullPath { get; set; }

        public CopyJob(string src, string dest)
        {
            SourceFullPath = src;
            DestinationFullPath = dest;
        }
    }
}
