﻿using Application.IRepositories;
using Application.IService;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepo userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            return await _userRepo.GetUserAsync(email, password);   
        }

        public async  Task<bool> RegisterAsync(string email, string password,string name)
        {
            bool emailExisted = await _userRepo.CheckEmailDuplicateAsync(email);
            if(emailExisted)
            {
                throw new Exception("Email already existed");
            }
            User newUser = new User
            {
                Email= email,
                Password= password,
                Name= name,
                RoleId=2
            };
            await _userRepo.AddAsync(newUser);
            return await _unitOfWork.SaveChangesAsync()>0;
        }
    }
}