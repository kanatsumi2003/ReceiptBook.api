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
        public async Task<ActionResult<ListResponseModel<User>>> GetAllUsers()
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

        [HttpGet]
        [Route("search_user_by_id/{userID}")]
        public async Task<ActionResult<ObjectResponseModel>> SearchUserByID(int userID)
        {
            try
            {
                return await _userService.SearchUserByID(userID);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }    
        }
        
        [HttpPost]
        [Route("create_new_user")]
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
        [HttpDelete]
        [Route("delete_user/{userID}")]
        public async Task<ActionResult<ObjectResponseModel>> DeleteUser(int userID)
        {
            try
            {
                return await _userService.DeleteUser(userID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update_user/{userID}")]
        public async Task<ActionResult<ObjectResponseModel>> UpdateUser(int userID, User user)
        {
            try
            {
                return await _userService.UpdateUser(userID, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 