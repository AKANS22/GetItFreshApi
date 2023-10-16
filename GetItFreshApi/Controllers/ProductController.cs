using GetItFreshApi.IRepository;
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

        public ProductController(IUnitOfWork unitOfWork, ILogger<ProductController>logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var Product = await unitOfWork.Product.GetAll();
                return Ok(Product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllProducts)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
