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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductController> logger;
        private readonly IMapper mapper;

        public ProductController(IUnitOfWork unitOfWork, ILogger<ProductController>logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var Products = await unitOfWork.Product.GetAll();

                var results = mapper.Map<IList<ProductDTO>>(Products);
                return Ok(results);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllProducts)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }

        [HttpGet("{id:string}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductById(string id)
        {
            try
            {
                var product = await unitOfWork.Product.Get(c => c.Id == id);
                var result = mapper.Map<ProductDTO>(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetProductById)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
