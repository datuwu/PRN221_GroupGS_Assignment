﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public  interface IUserGroupService
    {
        Task AddUserToGroup(UserGroup userGroup);
        Task<bool> BanUserFromGroup(int userId);
        Task<bool> PromoteUser(int userId);
        Task<bool> CheckUserExisted(int userId,int groupId);
        Task<UserGroup> FindUserInGroup(int userId,int groupId);
        Task<bool> OutGroup(int userId, int groupId);
    }
}
