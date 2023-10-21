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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<UserController> logger;
        private readonly IMapper mapper;

        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task <IActionResult> GetAllUsers()
        {
            try
            {
                var users = await unitOfWork.User.GetAll();
                var result = mapper.Map<IList<UserDTO>>(users);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetAllUsers)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }

        [HttpGet("{id:string}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                var user = await unitOfWork.User.Get(c => c.Id == id);
                var result = mapper.Map<UserDTO>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wromg in the {nameof(GetUserById)} endpoint");
                return StatusCode(500, "Internal server error, please try again later");
            }
        }
    }
}
