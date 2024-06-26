﻿using DataAccessLayer;
using DataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.IServices;

public interface IUserService
{
    Task<ObjectResponseModel> CreateNewUser(User user);
    Task<ListResponseModel<User>> GetAllUsers();
    Task<ObjectResponseModel> DeleteUser(int userID);
    Task<ObjectResponseModel> UpdateUser(int userID, User user);
    Task<ObjectResponseModel> SearchUserByID(int userID);
}