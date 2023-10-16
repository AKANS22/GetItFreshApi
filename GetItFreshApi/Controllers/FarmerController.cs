using GetItFreshApi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetItFreshApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<FarmerController> logger;

        public FarmerController(IUnitOfWork unitOfWork,  ILogger<FarmerController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllFarmers()
        {
            try
            {
                var farmers = await unitOfWork.Farmer.GetAll();
                return Ok(farmers);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllFarmers)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
