using BusinessLogicLayer.IServices;
using DataAccessLayer;
using DataAccessLayer.DTOs;
using DataAccessLayer.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        var data = _userRepository.GetAllUsers();
        return new ListResponseModel<User>(await data)
        {
            Data = await data,
            Message = "Get All User",
            Type = "User Accounts",
            Status = 200,
        };
    }

    public async Task<ObjectResponseModel> CreateNewUser(User user)
    {
        var data = new User();
        var message = "blank";
        var status = 500;
        if (await _userRepository.IsUserCCIDDuplicate(user.CCID))
        {
            return new ObjectResponseModel(data)
            {
                Message = "CCID is already taken",
                Status = 400,
            };
        }

        if (user.CCID.Length < 12)
        {
            message = "CCID must be at least 12 character";
            status = 400;
        }
        else
        {
            _userRepository.CreateNewUser(user);
            var rs = await _userRepository.SaveChangesAsync();
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
            message = "Successfully";
            status = 200;
        }
        return new ObjectResponseModel(data)
        {
            Message = message,
            Status = status,
        };
    }

    public async Task<ObjectResponseModel> DeleteUser(int userID)
    {
        var data = await _userRepository.GetUserByIDAsync(userID);
        string message = "blank";
        int status = 500;
        if (data == null)
        {
            message = "User is not Exist";
            status = 400;
        }
        else
        {
            _userRepository.DeleteUser(data);
            await _userRepository.SaveChangesAsync();
            message = "Successfully";
            status = 200;
        }
        return new ObjectResponseModel(data)
        {
            Message = message,
            Status = status,
            Type = "User Account",
        };
    }
    public async Task<ObjectResponseModel> UpdateUser(int userID, User user)
    {
        var data = await _userRepository.GetUserByIDAsync(userID);
        string message = "blank";
        int status = 500;

        if (data == null)
        {
            message = "User is not Exist";
            status = 400;
        }
        else
        {
            if (await _userRepository.IsUserCCIDDuplicate(user.CCID) && user.CCID != data.CCID)
            {
                return new ObjectResponseModel(data)
                {
                    Data = null,
                    Message = "CCID is already taken",
                    Status = 400,
                };
            }
            data.Name = user.Name;
            data.Role = user.Role;
            data.ContactNo = user.ContactNo;
            data.CCID = user.CCID;

            _userRepository.UpdateUser(data);
            await _userRepository.SaveChangesAsync();
            message = "Successfully";
            status = 200;
        }



        return new ObjectResponseModel(data)
        {
            Message = message,
            Status = status,
            Type = "User Account",
        };
    }
}