using BusinessLogicLayer.IServices;
using DataAccessLayer;
using DataAccessLayer.DTOs;
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
        [Route("get_all_users")]
        public async Task<ActionResult<ListResponseModel<User>>> GetUsers()
        {
            try
            {
                return await _userService.GetAllUsers();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<ObjectResponseModel>> AddNewUser(User user)
        {
            try
            {
                return await _userService.CreateNewUser(user);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }
    }
} 