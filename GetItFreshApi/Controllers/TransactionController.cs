using AutoMapper;
using GetItFreshApi.Entities;
using GetItFreshApi.IRepository;
using GetItFreshApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetItFreshApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<TransactionController> logger;
        private readonly IMapper mapper;

        public TransactionController(IUnitOfWork unitOfWork, ILogger<TransactionController> logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTransaction()
        {
            try
            {
                var transactions = await unitOfWork.Transaction.GetAll();
                var results = mapper.Map<IList<TransactionDTO>>(transactions);
                return Ok(results);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllTransaction)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }

        [HttpGet("{id:string}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTransactionById(string id)
        {
            try
            {
                var transaction = await unitOfWork.Transaction.Get(c => c.Id == id);
                var result = mapper.Map<TransactionDTO>(transaction);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetTransactionById)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
