using DataAccessLayer.DTOs;
using DataAccessLayer.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserContext _context;

    public UserRepository(UserContext context)
    {
        _context = context;
    }
    public async Task<bool> IsUserCCIDDuplicate(string userCCID) =>
        await _context.Users.AnyAsync(u => u.CCID.Equals(userCCID));
    
    public void CreateNewUser(User user) => _context.Users.Add(user);
    
    public async Task<List<User>> GetAllUsers() => await _context.Users.ToListAsync();
    
    public void DeleteUser(User user)
    {
        _context.Users.Remove(user);
    }
    
    public async Task<User> GetUserByIDAsync(int userID) => 
        await _context.Users.FirstOrDefaultAsync(u => u.ID.Equals(userID));
    
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    
    public void UpdateUser(User user) => _context.Users.Update(user);

    public async Task<User> SearchUserByID(int userID) =>
        await _context.Users.FirstOrDefaultAsync(u => u.ID.Equals(userID));
}