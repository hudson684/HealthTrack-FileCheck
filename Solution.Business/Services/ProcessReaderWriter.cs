using Solution.Data.Data;
using Solution.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Solution.Business.Services
{


    public class ProcessReaderWriter : IProcessReaderWriter
    {
        private string fileName = "Process.Json";

        public ProcessReaderWriter(Guid processToken)
        {
            fileName = "File_" + processToken.ToString() + ".json";
        }


        public ProcessData GetProcessData()
        {
            string fileInput = File.ReadAllText(fileName);

            //unsafe, handle proper errors if time allows.
            return JsonSerializer.Deserialize<ProcessData>(fileInput);

        }


        public void WriteProcessData(ProcessData data)
        {

            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, jsonString);
        }

    }
}
