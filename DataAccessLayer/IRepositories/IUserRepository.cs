using DataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessLayer.IRepository;

public interface IUserRepository
{
    Task<ObjectResponseModel> CreateNewUser(User user);
    Task<ICollection<User>> GetAllUsers();
}