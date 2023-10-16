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
        public async Task<IActionResult> GetAllTransaction()
        {
            try
            {
                var transaction = await unitOfWork.Transaction.GetAll();
                var result = mapper.Map<IList<TransactionDTO>>(transaction);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllTransaction)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
