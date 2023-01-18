using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Functional.Maybe;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class ApiUserRepository : IApiUserRepository
    {

        private readonly ApplicationDbContext _context;

        public ApiUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ApiUser entity)
        {
            await _context.Users.AddAsync(entity);
        }

        public async Task<Maybe<ApiUser>> ReadAsync(string email)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return entity.ToMaybe();
        }
        public async Task<Maybe<ApiUser>> ReadAsync(Guid id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return entity.ToMaybe();
        }

        public async Task<PagedList<ApiUser>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Users.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<ApiUser>(list, pageNumber, 10, _context.Users.Count());
        }

        public void Delete(ApiUser user)
        {
            _context.Users.Remove(user);
        }
    }
}
