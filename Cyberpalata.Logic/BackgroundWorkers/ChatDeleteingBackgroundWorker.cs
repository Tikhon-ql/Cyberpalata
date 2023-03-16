using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (DateTime.UtcNow.Hour == 3)
                {
                    using (var scope = _serviceFactory.CreateScope())
                    {
                        _chatRepository = scope.ServiceProvider.GetRequiredService<IChatRepository>();
                        _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                        var filter = new ChatFilter()
                        {
                            CurrentPage = 1,
                            PageSize = int.MaxValue,
                        };
                        var chats = await _chatRepository.GetPageListAsync(filter);
                        foreach (var chat in chats.Items)
                        {
                            if (chat.IsDeleted)
                                _chatRepository.Delete(chat);
                        }
                        await _unitOfWork.CommitAsync();
                    }
                }
                await Task.Delay(10000 * 60, stoppingToken);
            }
        }
    }
}
