using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Microsoft.EntityFrameworkCore;

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
            return userRefreshToken;
        }

        public void Delete(UserRefreshToken refreshToken)
        {
            _context.RefreshTokens.Remove(refreshToken);
        }

        //public async Task<Maybe<ApiUser>> GetUserByRefreshToken(string refreshToken)
        //{
        //    var token = await ReadAsync(refreshToken);
        //    if (token.HasValue)
        //        return token.Value.User;
        //    return Maybe.None;
        //}
    }
}
