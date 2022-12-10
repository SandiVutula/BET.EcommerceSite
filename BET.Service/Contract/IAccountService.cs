using BET.Data.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Service.Contract
{
    public interface IAccountService
    {
        Task<User> UserLoginAsync(User user);
        Task<User> UserRegisterAsync(User user);
    }
}
