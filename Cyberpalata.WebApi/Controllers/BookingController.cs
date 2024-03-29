﻿using CSharpFunctionalExtensions;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Booking;
using Cyberpalata.ViewModel.Request.Bookings;
using Cyberpalata.ViewModel.Response.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/booking")]
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public BookingController(IBookingService bookingService, IUnitOfWork uinOfWork, IRoomService roomService) : base(uinOfWork)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(BookingCreateViewModel request)
        {
            var userId = Guid.Parse(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value);
            var result = await _roomService.AddBookingToRoom(userId,request);
            if (result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }

        [Authorize]
        [HttpGet("calculateBookingPrice")]
        public async Task<IActionResult> CalculateBookingPrice(TimeSpan beg, int hours,int seatsCount)
        {
            return Ok(hours * seatsCount);
        }

        [Authorize]
        [HttpGet("getBooking")]
        public async Task<IActionResult> GetBooking(Guid id)
        {
            var viewModelResult = await _bookingService.GetBookingDetail(id);

            if (viewModelResult.IsFailure)
                return BadRequestJson(viewModelResult);

            return Ok(viewModelResult.Value);
        }

        [Authorize]
        [HttpGet("getBookingSmallInfo")]
        public async Task<IActionResult> GetBookingsSmallInfo(int page, bool isActual)
        {
            var userId = Guid.Parse(User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value);

            var filter = new BookingFilterBL
            {
                IsActual = isActual,
                CurrentPage = page,
                PageSize = 5,
                UserId = userId
            };

            var bookings = await _bookingService.GetPagedListAsync(filter);

            var viewModel = new List<BookingCollectionViewModel>();
            foreach (var item in bookings.Items)
            {
                viewModel.Add(new BookingCollectionViewModel
                {
                    Id = item.Id,
                    Begining = item.Begining.ToString(@"hh\:mm"),
                    HoursCount = item.HoursCount,
                    Price = item.Price,
                    Date = item.Date.ToString("yyyy-MM-dd"),
                    RoomName = item.Room.Name
                });
            }
            return Ok(new {Items = viewModel, TotalItemsCount = bookings.TotalItemsCount, PageSize = 5});
        }

        [Authorize]
        [HttpPost("finalizeBooking")]
        public async Task<IActionResult> FinalizeBooking(BookingFinalizationViewModel viewModel)
        {
            var userId = Guid.Parse(User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value);
            var result = await _bookingService.BookingPay(viewModel, userId);
            if(result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }

        [Authorize]
        [HttpGet("getBasket")]
        public async Task<IActionResult> GetBasket()
        {
            var userId = Guid.Parse(User.Claims.First(claim=>claim.Type == JwtRegisteredClaimNames.Sid).Value);
            var filter = new BookingFilterBL
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
                IsActual = true,
                UserId = userId,
                IsPaid = false
            };
            var bookings = await _bookingService.GetPagedListAsync(filter);

            var viewModel = new List<BookingCollectionViewModel>();
            foreach (var item in bookings.Items)
            {
                viewModel.Add(new BookingCollectionViewModel
                {
                    Id = item.Id,
                    Begining = item.Begining.ToString(@"hh\:mm"),
                    HoursCount = item.HoursCount,
                    Price = item.Price,
                    Date = item.Date.ToString("yyyy-MM-dd"),
                    RoomName = item.Room.Name,
                    Seats = item.Seats.Select(seat=>seat.Number).ToList(),
                });
            }
            return Ok(viewModel);
        }
    }
}
