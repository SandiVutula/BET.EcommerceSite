using BET.Data.EcommerceDbContext;
using BET.Data.GenericRepository;
using BET.Data.Model.Dto;
using BET.Service.Contract;
using BET.Shared.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Service.Service
{
    public class AccountService : IAccountService
    {
        private readonly EntiyFrameworkDbContext _context;
        public AccountService(EntiyFrameworkDbContext context)
        {
            _context = context;
        }

        public async Task<User> UserLoginAsync(User user)
        {
            var password = PasswordGenerator.HashPassword(user.Password);
            var userLogin = await _context.Users.Where(u => u.EmailAddress == user.EmailAddress && u.Password == password).FirstOrDefaultAsync();
            return userLogin;

        }

        public async Task<User> UserRegisterAsync(User user)
        {
            var password = PasswordGenerator.HashPassword(user.Password);
            var userRegister = await _context.Users.Where(u => u.EmailAddress == user.EmailAddress && u.Password == password).FirstOrDefaultAsync();
            return userRegister;

        }
    }
}
