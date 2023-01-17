using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Functional.Maybe;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class UserRefreshTokenRepository : IUserRefreshTokenRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRefreshTokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserRefreshToken entity)
        {
            await _context.RefreshTokens.AddAsync(entity);
        }

        public async Task<UserRefreshToken> ReadAsync(string refreshToken)
        {
            var userRefreshToken = await _context.RefreshTokens.Include(i => i.User).SingleAsync(rt => rt.RefreshToken == refreshToken);
            return userRefreshToken;
        }

        public void Delete(UserRefreshToken refreshToken)
        {
            _context.RefreshTokens.Remove(refreshToken);
        }

        public async Task<ApiUser> GetUserByRefreshToken(string refreshToken)
        {
            var token = await _context.RefreshTokens.SingleAsync(rt => rt.RefreshToken == refreshToken);
            return token.User;
        }
    }
}
