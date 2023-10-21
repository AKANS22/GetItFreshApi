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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllMerchant()
        {
            try
            {
                var Merchants = await unitOfWork.Merchant.GetAll();
                var results = mapper.Map<IList<MerchantDTO>>(Merchants);
                return Ok(results);
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllMerchant)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }

        [HttpGet("{id:string}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMerchantById(string id)
        {
            try
            {
                var merchant = await unitOfWork.Merchant.Get(c => c.Id == id);
                var result = mapper.Map<MerchantDTO>(merchant);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetMerchantById)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
