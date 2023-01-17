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

        public async Task<Maybe<UserRefreshToken>> ReadAsync(string refreshToken)
        {
            var userRefreshToken = await _context.RefreshTokens.Include(i => i.User).FirstOrDefaultAsync(rt => rt.RefreshToken == refreshToken);
            return userRefreshToken.ToMaybe();
        }

        public void Delete(UserRefreshToken refreshToken)
        {
            _context.RefreshTokens.Remove(refreshToken);
        }

        public async Task<Maybe<ApiUser>> GetUserByRefreshToken(string refreshToken)
        {
            var token = await ReadAsync(refreshToken);
            if (token.HasValue)
                return token.Value.User.ToMaybe();
            return Maybe<ApiUser>.Nothing;
        }
    }
}
