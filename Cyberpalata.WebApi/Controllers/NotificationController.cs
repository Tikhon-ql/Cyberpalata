﻿using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/notifications")]
    public class NotificationController : BaseController
    {

        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService,IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _notificationService = notificationService;
        }

        [Authorize]
        [HttpGet("getNotifications")]
        public async Task<IActionResult> GetNotifications()
        {
            var userId = Guid.Parse(User.Claims.First(claim=>claim.Type == JwtRegisteredClaimNames.Sid).Value);

            var filter = new NotificationFilterBL
            {
                CurrentPage = 1,
                PageSize = 10,
                IsActual = true,
                UserId = userId,
            };
            var notifications = await _notificationService.GetPagedList(filter);
            return Ok(notifications);
        }
    }
}
