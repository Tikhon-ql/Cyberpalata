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
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Users.AddAsync(entity);
        }

        public async Task<ApiUser> ReadAsync(string email)
        {
            var entity = await _context.Users.SingleAsync(u => u.Email == email);
            return entity;
        }

        private PagedList<ApiUser> GetPageList(int pageNumber)
        {
            var list = _context.Users.Skip((pageNumber - 1) * 10).Take(10).ToList();
            return new PagedList<ApiUser>(list, pageNumber,10,_context.Users.Count());
        }

        public async Task<PagedList<ApiUser>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }
    }
}
