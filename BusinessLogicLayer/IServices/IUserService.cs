using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.IServices;

public interface IUserService
{
    Task<ActionResult<IEnumerable<User>>> GetAllUsers();
    Task CreateNewUser(User user);
}