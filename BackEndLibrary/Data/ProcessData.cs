using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Solution.Data.Data
{
    public class ProcessData
    {

        public int Total { get; set; } = 0;
        public int CurrentProcessed { get; set; } = 0;

        [JsonIgnore]
        public decimal Progress
        {
            get
            {
                if (Total == 0)
                    return 0;
                

                return (decimal)((CurrentProcessed / Total) * 100.00);
            }
        }

        [JsonIgnore]
        public bool IsComplete { get
            {
                return Total != 0 && CurrentProcessed == Total;
            }
        }
    }
}
