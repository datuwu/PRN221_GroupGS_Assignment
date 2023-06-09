﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<bool> CheckEmailDuplicateAsync(string email);
        Task<User> GetUserAsync(string email,string password);
        Task<List<User>> GetUsersByGroupId(int groupId);
        Task<bool> SoftRemove(int userId);
        Task<List<User>> GetAllUserV2();
        Task<User> GetUserWithRole(int id);
    }
}
