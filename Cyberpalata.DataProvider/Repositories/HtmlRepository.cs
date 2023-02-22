using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class HtmlRepository : IHtmlRepository
    {
        private readonly ApplicationDbContext _context;
        public HtmlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HtmlContent> ReadAsync(string id)
        {
            var html = await _context.Htmls.FirstOrDefaultAsync(h=>h.Id == id);
            return html;
        }
    }
}
