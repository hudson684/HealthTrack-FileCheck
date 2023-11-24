using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class FileDetails
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public byte[]? FileHash { get; set; }
        public byte[]? DataHash { get; set; }
    }
}
