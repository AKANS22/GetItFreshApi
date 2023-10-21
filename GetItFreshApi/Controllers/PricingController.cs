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
    public class PricingController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<PricingController> logger;
        private readonly IMapper mapper;

        public PricingController(IUnitOfWork unitOfWork,  ILogger<PricingController> logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPricing()
        {
            try
            {
                var Pricings = await unitOfWork.Pricing.GetAll();
                var results = mapper.Map<IList<PricingDTO>>(Pricings);
                return Ok(results);
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllPricing)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }

        [HttpGet("{id:string}")]
        public async Task<IActionResult> GetPricingById(string id)
        {
            try
            {
                var pricing = await unitOfWork.Pricing.Get(c => c.Id == id);
                var result = mapper.Map<PricingDTO>(pricing);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetPricingById)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
