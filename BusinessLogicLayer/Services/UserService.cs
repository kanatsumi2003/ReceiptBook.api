using BusinessLogicLayer.IServices;
using DataAccessLayer;
using DataAccessLayer.DTOs;
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

    public async Task<ListResponseModel<User>> GetAllUsers()
    {
        Task<ICollection<User>> data = _userRepository.GetAllUsers();
        return new ListResponseModel<User>(await data)
        {
            Data = await data,
            Type = "User Accounts"
        };
    } 

    public async Task<ObjectResponseModel> CreateNewUser(User user)
    {
        return await _userRepository.CreateNewUser(user);
    }
    
}