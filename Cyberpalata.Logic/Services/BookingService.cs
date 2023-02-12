using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Booking;

namespace Cyberpalata.Logic.Services
{
    internal class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IApiUserRepository _userRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository repository,
            IApiUserRepository userRepository, 
            IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Maybe<BookingDto>> ReadAsync(Guid id)
        {
            var booking = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<BookingDto>>(booking);
        }

        public async Task<PagedList<BookingDto>> GetPagedListAsync(BaseFilter filter)
        {
            var list = await _repository.GetPageListAsync(filter);
            return _mapper.Map<PagedList<BookingDto>>(list);
        }
        //???Is it an exception
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
            //resultSeats = resultSeats.OrderBy(seat => seat.Number).ToList();
            //foreach (var bookingSeat in booking.Value.Seats)
            //{
            //    resultSeats[bookingSeat.Number - 1].Type = SeatType.UsersSeat;
            //}
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
    }
}
