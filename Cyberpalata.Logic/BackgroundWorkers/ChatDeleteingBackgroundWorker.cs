using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;

namespace Cyberpalata.Logic.BackgroundWorkers
{
    public class ChatDeleteingBackgroundWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceFactory;
        private IUnitOfWork _unitOfWork;
        private IChatRepository _chatRepository;

        public ChatDeleteingBackgroundWorker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceFactory = serviceScopeFactory;
        }

        private void SetServices(IServiceScope scope)
        {
            _chatRepository = scope.ServiceProvider.GetRequiredService<IChatRepository>();
            _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        }

        private async Task<List<Chat>> GetChats()
        {
            var filter = new ChatFilter()
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
            };
            var chats = await _chatRepository.GetPageListAsync(filter);
            return chats.Items;
        }

        private void HandleChats(List<Chat> chats)
        {
            foreach (var chat in chats)
            {
                if (chat.IsDeleted)
                    _chatRepository.Delete(chat);
            }
        }
 
        private async Task DoWork()
        {
            using (var scope = _serviceFactory.CreateScope())
            {
                SetServices(scope);
                var chats = await GetChats();
                HandleChats(chats);
                await _unitOfWork.CommitAsync();
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (DateTime.UtcNow.Hour == 3)
                {
                    await DoWork();
                }
                await Task.Delay(10000 * 60, stoppingToken);
            }
        }
    }
}
