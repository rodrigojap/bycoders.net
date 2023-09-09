using bycoders.cnab.api.Models.Input;
using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.data;
using Microsoft.AspNetCore.Mvc;

namespace bycoders.cnab.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CNABOperationsController : ControllerBase
    {
        private readonly IProcessCnabOperations ProcessCnabOperations;
        private readonly ApplicationDbContext ApplicationDbContext;

        public CNABOperationsController(IProcessCnabOperations processCnabOperations, ApplicationDbContext applicationDbContext)
        {
            ProcessCnabOperations = processCnabOperations;
            ApplicationDbContext = applicationDbContext;
            ApplicationDbContext.PopulateDb();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string GetSummary(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CnabFormFileInput File)
        {
            try
            {
                await ProcessCnabOperations.ProcessCnabFormFile(File.FormFile);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}
