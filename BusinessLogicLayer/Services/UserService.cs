using BusinessLogicLayer.IServices;
using DataAccessLayer;
using DataAccessLayer.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers() => await _userRepository.GetAllUsers();

    public async Task CreateNewUser(User user)
    {
        await _userRepository.CreateNewUser(user);
    }
}