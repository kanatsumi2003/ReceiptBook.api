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
        Task<List<User>> data = _userRepository.GetAllUsers();
        return new ListResponseModel<User>(await data)
        {
            Data = await data,
            Message = "Get All User",
            Type = "User Accounts",
            Status = 200,
        };
    } 

    public async Task<ObjectResponseModel> CreateNewUser(User User)
    {
        return await _userRepository.CreateNewUser(User);
    }
    
    public async Task<ObjectResponseModel> DeleteUser(int UserID)
    {
        var data = await _userRepository.DeleteUser(UserID);
        return new ObjectResponseModel(data)
        {
            Data = data,
            Message = "Remove User Account",
            Status = 200,
            Type = "User Account",
        };
    }
}