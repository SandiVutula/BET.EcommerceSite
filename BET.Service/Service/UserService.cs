using BET.Data.GenericRepository;
using BET.Data.Model;
using BET.Service.Contract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BET.Service.Service
{
    public class UserService : IUserService
    {

        private readonly IRepositoryReadOnly _iRepository;
        public UserService(IRepositoryReadOnly iRepository)
        {
            _iRepository = iRepository;
        }

        public User GetUserById(int userId)
        {
            var user =  _iRepository.GetById<User>(userId);
            return user;
        }
    }
}
