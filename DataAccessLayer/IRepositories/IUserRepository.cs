using DataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.IRepository;

public interface IUserRepository
{
    Task<bool> IsUserCCIDDuplicate(string userCCID);
    void CreateNewUser(User user);
    Task<List<User>> GetAllUsers();
    void DeleteUser(User user);
    Task<User> GetUserByIDAsync(int userID);
    Task<int> SaveChangesAsync();
    void UpdateUser(User user);
};
