using GetItFreshApi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetItFreshApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<PricingController> logger;

        public PricingController(IUnitOfWork unitOfWork,  ILogger<PricingController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllPricing()
        {
            try
            {
                var Pricing = await unitOfWork.Pricing.GetAll();
                return Ok(Pricing);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllPricing)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
