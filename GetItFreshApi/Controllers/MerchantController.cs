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
    public class MerchantController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<MerchantController> logger;
        private readonly IMapper mapper;

        public MerchantController(IUnitOfWork unitOfWork,  ILogger<MerchantController> logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMerchant()
        {
            try
            {
                var Merchants = await unitOfWork.Merchant.GetAll();
                var result = mapper.Map<IList<MerchantDTO>>(Merchants);
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllMerchant)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
