using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;
        private readonly IMapper _mappper;

        public NotificationService(INotificationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mappper = mapper;
        }

        public async Task<PagedList<NotificationDto>> GetPagedList(NotificationFilterBL filter)
        {
            var list = await _repository.GetPageListAsync(_mappper.Map<NotificationFilter>(filter));
            return _mappper.Map<PagedList<NotificationDto>>(list);
        }

        public async Task SetNotificationProcededDate(List<NotificationDto> notifications, Guid userId)
        {
            var filter = new NotificationFilter
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
                UserId = userId,
                NotificationIds = notifications.Select(n=>n.Id).ToList()
            };
            var notificationList = await _repository.GetPageListAsync(filter);
            foreach(var notification in notificationList.Items)
            {
                notification.SentDate = DateTime.UtcNow;
            }
        }
    }
}
