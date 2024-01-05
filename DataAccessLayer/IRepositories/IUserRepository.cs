using DataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.IRepository;

public interface IUserRepository
{
    Task<ObjectResponseModel> CreateNewUser(User user);
    Task<List<User>> GetAllUsers();
    Task<User> DeleteUser(int userID);
}