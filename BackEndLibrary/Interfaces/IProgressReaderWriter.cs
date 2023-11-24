using Solution.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Interfaces
{
    public interface IProcessReaderWriter
    {
        ProcessData GetProcessData();
        void WriteProcessData(ProcessData data);
    }
}
