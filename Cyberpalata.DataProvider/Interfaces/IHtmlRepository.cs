using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IHtmlRepository
    {
        Task<HtmlContent> ReadAsync(string id);
    }
}
