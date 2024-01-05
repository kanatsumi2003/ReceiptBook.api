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

    public async Task<ObjectResponseModel> CreateNewUser(User user)
    {
        var data = new User();
        var message = "blank";
        var status = 500;
        if (user.CCID.Length < 12)
        {
            message = "CCID must be at least 12 character";
            status = 400;
        }
        else
        {
            _context.Users.Add(user);
            var rs = await _context.SaveChangesAsync();
            if (rs > 0)
            {
                data = (new User
                {
                    ID = user.ID,
                    Name = user.Name,
                    Role = user.Role,
                    ContactNo = user.ContactNo,
                    CCID = user.CCID
                });
            }
        }

        return new ObjectResponseModel(data)
        {
            Message = message,
            Status = status,
        };
    }

    public async Task<List<User>> GetAllUsers() => await _context.Users.ToListAsync();


    public async Task<User> DeleteUser(int userID)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.ID.Equals(userID));
        if (user != null)
;        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
        return user;
    }
}