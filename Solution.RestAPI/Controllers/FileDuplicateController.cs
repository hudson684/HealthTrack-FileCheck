using Microsoft.AspNetCore.Mvc;
using Solution.Busienss.Services;
using Solution.Data;
using Solution.Data.Data;
using Solution.Data.Interfaces;

namespace Solution.RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileDuplicateController : ControllerBase
    {

        private readonly ILogger<FileDuplicateController> _logger;
        private IDuplicateChecker _duplicateCheckerService;

        public FileDuplicateController(ILogger<FileDuplicateController> logger, IDuplicateChecker duplicateChecker)
        {
            _logger = logger;
            _duplicateCheckerService = duplicateChecker;
        }

        [HttpGet(Name = "GetData")]
        public List<int> Get()
        {
            return new List<int> { 0, 1, 2, 3 };
        }

        [HttpPost(Name = "Post")]
        public List<DuplicateGroup> Post([FromBody] DuplicatePostData data)
        {
             return _duplicateCheckerService.GetDuplicateFilesFromPath(data.Directory);
        }
    }
}
