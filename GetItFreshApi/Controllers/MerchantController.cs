using GetItFreshApi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetItFreshApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<MerchantController> logger;

        public MerchantController(IUnitOfWork unitOfWork,  ILogger<MerchantController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllMerchant()
        {
            try
            {
                var Merchants = await unitOfWork.Merchant.GetAll();
                return Ok(Merchants);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllMerchant)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
