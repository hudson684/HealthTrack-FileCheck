using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Data;

namespace Solution.Data.Interfaces
{
    public interface IDuplicateChecker
    {
        List<DuplicateGroup> GetDuplicateFilesFromPath(string directoryPath);
    }
}

