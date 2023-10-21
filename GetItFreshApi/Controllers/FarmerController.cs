using AutoMapper;
using GetItFreshApi.IRepository;
using GetItFreshApi.Models;
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
        private readonly IMapper mapper;
        public FarmerController(IUnitOfWork unitOfWork, ILogger<FarmerController> logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllFarmers()
        {
            try
            {
                var farmers = await unitOfWork.Farmer.GetAll();
                var results = mapper.Map<IList<FarmerDTO>>(farmers);
                return Ok(results);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllFarmers)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }


        [HttpGet("{id:string}")]
        public async Task<IActionResult> GetFarmerById( string id)
        {
            try
            {
                var farmer = await unitOfWork.Farmer.Get( c => c.Id == id, new List<string> { "Products"});
                var result = mapper.Map<FarmerDTO>(farmer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetFarmerById)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
