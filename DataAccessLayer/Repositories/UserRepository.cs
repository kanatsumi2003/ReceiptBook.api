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

    public async Task CreateNewUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }
}