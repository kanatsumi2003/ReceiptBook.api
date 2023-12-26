using Microsoft.AspNetCore.Mvc;

namespace DataAccessLayer.IRepository;

public interface IUserRepository
{
    Task CreateNewUser(User user);
    Task<ActionResult<IEnumerable<User>>> GetAllUsers();
}