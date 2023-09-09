using bycoders.cnab.api.Models.Input;
using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.data;
using bycoders.cnab.domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bycoders.cnab.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CNABOperationsController : ControllerBase
    {
        private readonly IProcessCnabOperations ProcessCnabOperations;
        private readonly IGetSummaryOperationsByStore SummaryOperationsByStore;
        private readonly ApplicationDbContext ApplicationDbContext;
        private readonly ICNABOperationsRepository CnabOperationsRepository;

        public CNABOperationsController(
            IProcessCnabOperations processCnabOperations,
            IGetSummaryOperationsByStore summaryOperationsByStore,
            ApplicationDbContext applicationDbContext, 
            ICNABOperationsRepository operationsRepository
            )
        {
            ProcessCnabOperations = processCnabOperations;
            SummaryOperationsByStore = summaryOperationsByStore;
            ApplicationDbContext = applicationDbContext;
            CnabOperationsRepository = operationsRepository;
            ApplicationDbContext.PopulateDb();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await CnabOperationsRepository.GetStores();                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter Lojas: [{ex.Message}]");
            }                        
        }

        [HttpGet("{storeName}")]
        public async Task<IActionResult> GetDataByStoreName(string storeName)
        {
            try
            {
                var result = await SummaryOperationsByStore.GetSummary(storeName);
                return Ok(result);  
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter operações da loja '{storeName}': [{ex.Message}]");
            }
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
