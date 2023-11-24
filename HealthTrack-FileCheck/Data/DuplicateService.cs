using Solution.Data;
using Solution.Data.Data;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace HealthTrack_FileCheck.Data
{
    public class DuplicateService
    {

        private readonly HttpClient _httpClient;

        public DuplicateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DuplicateGroup>> GetDuplicatesAsync(string directory) {

            DuplicatePostData data = new DuplicatePostData() { Directory = directory };

            string jsonData = JsonSerializer.Serialize(data);

            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");

            using HttpResponseMessage response = await _httpClient.PostAsync( "/fileduplicate", content);

            string jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
            List<DuplicateGroup> duplicates = JsonSerializer.Deserialize<List<DuplicateGroup>>(jsonResponse);
            return duplicates;
        }
    }
}
