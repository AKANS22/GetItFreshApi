using GetItFreshApi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetItFreshApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<UserController> logger;

        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            
        }

        [HttpGet]
        public async Task <IActionResult> GetAllUsers()
        {
            try
            {
                var users = await unitOfWork.User.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllUsers)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
