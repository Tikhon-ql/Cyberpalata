using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.ViewModel.Request.Bookings;
using Cyberpalata.ViewModel.Response;
using Cyberpalata.ViewModel.Response.Booking;
using Cyberpalata.ViewModel.Response.Booking.Enum;
using Cyberpalata.ViewModel.Response.Rooms.GamingRoom;

namespace Cyberpalata.Logic.Services
{
    internal class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly ISeatService _seatService;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository repository,
            IUserRepository userRepository, 
            IMapper mapper, 
            ISeatService seatService,
            IPaymentService paymentService)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _seatService = seatService;
            _paymentService = paymentService;
        }
        public async Task<Maybe<BookingDto>> ReadAsync(Guid id)
        {
            var booking = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<BookingDto>>(booking);
        }

        public async Task<PagedList<BookingDto>> GetPagedListAsync(BookingFilterBL filter)
        {
            var list = await _repository.GetPageListAsync(_mapper.Map<BookingFilter>(filter));
            return _mapper.Map<PagedList<BookingDto>>(list);
        }

        public async Task<Result<BookingDetailsViewModel>> GetBookingDetail(Guid id)
        {
            var booking = await _repository.ReadAsync(id);
            if (booking.HasNoValue)
                return Result.Failure<BookingDetailsViewModel>($"Booking with id: {id} doen't exist!");
            var viewModel = new BookingDetailsViewModel
            {
                RoomName = booking.Value.Room.Name,
                Date = booking.Value.Date.ToString(),
                Begining = booking.Value.Begining.ToString(@"hh\:mm"),
                Price = booking.Value.Price,
                HoursCount = booking.Value.HoursCount,
                Seats = new List<SeatViewModel>(),
            };
            var seats = await _seatService.GetSeatsByRoomIdAsync(booking.Value.Room.Id);
            var resultSeats = new List<SeatViewModel>();
            seats.Value.ForEach((seat =>
            {
                resultSeats.Add(new SeatViewModel
                {
                    Number = seat.Number,
                    Type = SeatType.Free,
                });
            }));
            SetUsersSeats(resultSeats, booking.Value.Seats);
            viewModel.Seats = resultSeats;
            return Result.Success(viewModel);
        }
        private void SetUsersSeats(List<SeatViewModel> resultSeats, List<Seat> bookingsSeats)
        {
            resultSeats = resultSeats.OrderBy(seat => seat.Number).ToList();
            foreach (var bookingSeat in bookingsSeats)
            {
                resultSeats[bookingSeat.Number - 1].Type = SeatType.UsersSeat;
            }
        }

        private async Task<Result> SetIsPaidState(Guid bookingId)
        {
            var booking = await _repository.ReadAsync(bookingId);
            if (booking.HasNoValue)
                return Result.Failure($"Booking with id: {bookingId} not found");
            booking.Value.IsPaid = true;
            return Result.Success();
        }

        public async Task<Result> BookingPay(BookingFinalizationViewModel viewModel, Guid userId)
        {
            var booking = await _repository.ReadAsync(viewModel.BookingId);

            if (booking.HasNoValue)
                return Result.Failure($"Booking with id: {viewModel.BookingId} not found");

            var transactionResult = _paymentService.MakeTransaction(new Card
            {
                CardCvv = viewModel.CardCvv,
                CardDate = viewModel.CardDate,
                CardNumber = viewModel.CardNumber.Trim()
            },booking.Value.Price, userId);
            if (transactionResult.IsFailure)
                return transactionResult;
            var bookingIsPaidStateSettingResult = await SetIsPaidState(viewModel.BookingId);
            return bookingIsPaidStateSettingResult;
        }
    }
}
