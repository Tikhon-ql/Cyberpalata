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

        public async Task<UserRefreshToken> ReadAsync(string userEmail)
        {
            return await _context.RefreshTokens.SingleAsync(t => t.UserEmail == userEmail);
        }

        public async Task DeleteAsync(string userEmail)
        {
            var entity = await ReadAsync(userEmail);
            _context.RefreshTokens.Remove(entity);
        }     
    }
}
