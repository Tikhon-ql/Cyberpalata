using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class ApiUserRepository :BaseRepository<ApiUser>, IApiUserRepository
    {
        public ApiUserRepository(ApplicationDbContext context, IConfiguration configuration) : base(context,configuration)
        {
        }

        public async Task<Maybe<ApiUser>> ReadAsync(string email)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return entity;
        }

        public override async Task<PagedList<ApiUser>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Users.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<ApiUser>(list, pageNumber, 10, _context.Users.Count());
        }
    }
}
