using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Solution.Data.Enums;

namespace Solution.Data
{
    public class DuplicateGroup
    {

        public DuplicateType DuplicateType { get; set; }
        [JsonPropertyName("duplicates")]
        public List<string> Duplicates { get; set; }

        public DuplicateGroup(DuplicateType duplicateType, List<string> duplicates)
        {
            DuplicateType = duplicateType;
            Duplicates = duplicates;
        }
    }
}
