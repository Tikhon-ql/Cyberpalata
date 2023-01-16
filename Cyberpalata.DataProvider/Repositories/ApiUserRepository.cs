using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
            return entity;
        }
        public async Task<Maybe<ApiUser>> ReadAsync(Guid id)
        {
            var entity = await _context.Users.SingleAsync(u => u.Id == id);
            return entity;
        }

        private PagedList<Maybe<ApiUser>> GetPageList(int pageNumber)
        {
            var list = _context.Users.Skip((pageNumber - 1) * 10).Take(10).Select(user=>(Maybe<ApiUser>)user).ToList();
            return new PagedList<Maybe<ApiUser>>(list,pageNumber,10,_context.Users.Count());
        }

        public async Task<PagedList<Maybe<ApiUser>>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }

        public void Delete(ApiUser user)
        {
            _context.Users.Remove(user);
        }
    }
}
