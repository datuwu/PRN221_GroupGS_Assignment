﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public  interface IUserService
    {
        Task<bool> RegisterAsync(string email, string password,string name);
        Task<User> LoginAsync(string email, string password); 
    }
}