using BET.Data.GenericRepository;
using BET.Data.Model;
using BET.Service.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Service.Service
{
    public class RefreshTokenService: IRefreshTokenService
    {
        private readonly IRepository _iRepository;
        public RefreshTokenService(IRepository iRepository)
        {
            _iRepository = iRepository;
        }
        public async Task SaveToken(string refreshToken)
        {
            _iRepository.Create(refreshToken);
            await _iRepository.SaveAsync();
        }

        public async Task DeleteAllTokens(Guid userId)
        {
            IEnumerable<RefreshToken> refreshTokens =  await _iRepository.GetAsync<RefreshToken>(t => t.UserId == userId);
            if(refreshTokens != null)
            {
                _iRepository.Remove(refreshTokens);
                await _iRepository.SaveAsync();
            }
        }
    }
}
