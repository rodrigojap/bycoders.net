using bycoders.cnab.api.Models.Input;
using bycoders.cnab.application.UseCases.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bycoders.cnab.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CNABOperationsController : ControllerBase
    {
        private readonly IProcessCnabOperations ProcessCnabOperations;

        public CNABOperationsController(IProcessCnabOperations processCnabOperations)
        {
            ProcessCnabOperations = processCnabOperations;
        }

        // GET: api/<CNABOperationsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CNABOperationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CNABOperationsController>
        [HttpPost]
        public IActionResult Post([FromForm] CnabFormFileInput File)
        {
            ProcessCnabOperations.ProcessCnabFormFile(File.FormFile);

            return Ok("ai deus");
        }
    }
}
