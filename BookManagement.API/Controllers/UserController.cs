using BusinessLogicLayer.IServices;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManagement.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers() => await _userService.GetAllUsers();

        [HttpPost]
        public async Task AddNewUser(User user)
        {
            try
            {
                await _userService.CreateNewUser(user);
            } catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
    }
}
