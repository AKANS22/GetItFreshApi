using GetItFreshApi.IRepository;
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

        public TransactionController(IUnitOfWork unitOfWork, ILogger<TransactionController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransaction()
        {
            try
            {
                var transaction = await unitOfWork.Transaction.GetAll();
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllTransaction)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
