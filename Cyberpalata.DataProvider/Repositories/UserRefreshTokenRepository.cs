using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
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
            if(entity== null) throw new ArgumentNullException(nameof(entity));
            await _context.RefreshTokens.AddAsync(entity);
        }

        public async Task<UserRefreshToken> ReadAsync(Guid userId)
        {
            return await _context.RefreshTokens.SingleAsync(t => t.User.Id == userId);
        }

        public async Task DeleteAsync(string refreshToken)
        {
            var entity = await _context.RefreshTokens.SingleAsync(t => t.RefreshToken == Encoding.UTF8.GetBytes(refreshToken));
            _context.RefreshTokens.Remove(entity);
        }

        public async Task<Result<ApiUser>> GetUserByRefreshToken(string refreshToken)
        {
            try
            {
                var token = await _context.RefreshTokens.SingleAsync(rt => rt.RefreshToken == Encoding.UTF8.GetBytes(refreshToken));
                return Result.Ok(token.User);
            }
            catch(Exception ex)
            {
                //?????
                return (Result<ApiUser>)Result.Fail(ex.Message);
            }
        }
        //??????????
        public async Task<bool> IsAlreadyHasToken(Guid userId)
        {
            try
            {
                var res = await ReadAsync(userId);
                return true;
            }
            catch(InvalidOperationException exception)
            {
                return false;
            }
        }

        public async Task DeleteAsync(Guid userId)
        {
            var entity = await ReadAsync(userId);
            _context.RefreshTokens.Remove(entity);
        }
    }
}
