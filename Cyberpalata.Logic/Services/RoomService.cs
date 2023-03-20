using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Room;
using Cyberpalata.ViewModel.Request.Booking;
using Cyberpalata.ViewModel.Request.Filters;
using Cyberpalata.ViewModel.Request.Room;
using Cyberpalata.ViewModel.Request.Seats;
using Microsoft.Extensions.Configuration;

namespace Cyberpalata.Logic.Services
{
    internal class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly ISeatService _seatService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IBookingRepository _bookingRepository;

        public RoomService(IRoomRepository repository, ISeatService seatService,IUserRepository userRepository,
            IMapper mapper, IConfiguration configuration, IBookingRepository bookingRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _seatService = seatService;
            _configuration = configuration;
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<PagedList<RoomDto>> GetPagedListAsync(RoomFilterBL filter)
        {
            var list = await _repository.GetPageListAsync(_mapper.Map<RoomFilter>(filter));
            return _mapper.Map<PagedList<RoomDto>>(list);
        }

        private List<Seat> GetFreeSeats(BookingCreateViewModel viewModel, Room room)
        {
            var freeSeats = new List<Seat>();
            var bookings = room.Bookings.Where(b => (b.Date == viewModel.Date
                && ((viewModel.Begining <= b.Begining
                    && viewModel.Date.Add(viewModel.Begining).AddHours(viewModel.HoursCount) > b.Date.Add(b.Begining))
                || (b.Begining <= viewModel.Begining
                    && viewModel.Date.Add(viewModel.Begining) < b.Date.Add(b.Begining).AddHours(b.HoursCount))))).ToList();
            foreach (var seat in viewModel.Seats)
            {
                bool isFree = true;
                foreach(var booking in bookings)
                {
                    bool isBookingHasSeat = booking.Seats.FirstOrDefault(s=>s.Number == seat) != null;
                    if(isBookingHasSeat)
                    {
                        isFree = false;
                        break;
                    }
                }
                if(isFree)
                {
                    var freeSeat = room.Seats.First(s=>s.Number == seat);
                    freeSeats.Add(freeSeat);
                }
            }
            return freeSeats;
        }
        
        private Booking CreateBookingWithSeats(BookingCreateViewModel viewModel, Room room)
        {
            var seats = GetFreeSeats(viewModel, room);
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                Seats = seats,
                Date = viewModel.Date,
                Begining = viewModel.Begining,
                HoursCount = viewModel.HoursCount
            }; 
            foreach (var seat in seats)
            {
                seat.Bookings.Add(booking);
            }
            return booking;
        }

        public async Task<Result> AddBookingToRoom(Guid userId, BookingCreateViewModel viewModel)
        {
            var result = ValidateBooking(viewModel);
            if (result.IsFailure)
                return result;
            var room = await _repository.ReadAsync(viewModel.RoomId);
            if (room.HasNoValue)
                return Result.Failure($"There aren't roo with id:{viewModel.RoomId}");
            var booking = CreateBookingWithSeats(viewModel, room.Value);
            var user = await _userRepository.ReadAsync(userId);
            booking.User = user.Value;
            booking.Room = room.Value;
            booking.IsPaid = false;
            booking.Price = viewModel.Price;
            room.Value.Bookings.Add(booking);
            await _bookingRepository.CreateAsync(booking);
            return Result.Success();
        }

        private Result ValidateBooking(BookingCreateViewModel viewModel)
        {
            if (viewModel.Seats.Count == 0)
                return Result.Failure("Seats collection is empty");
            if (viewModel.Date.Add(viewModel.Begining) <= DateTime.UtcNow)
                return Result.Failure("You can’t go back in time");
            int bookingMakingMaxAheadDays = int.Parse(_configuration["BookingSettings:BookingMaxMakingAheadDays"]);
            if ((viewModel.Date - DateTime.Now).Days >= bookingMakingMaxAheadDays)
                return Result.Failure("Incorrect date: You can make a booking only on 2 weeks ahead");
            return Result.Success();
        }

   
        //public async Task<Maybe<List<RoomDto>>> SearchRooms(SearchRoomViewModel viewModel)
        //{
        //    var rooms = await _repository.GetAll();
        //    var resultList = new List<RoomDto>();
        //    foreach (var room in rooms)
        //    {
        //        var seats = await _seatService.GetSeatsByRoomInRangeIdAsync(new SeatsGettingViewModel
        //        {
        //            RoomId = room.Id,
        //            Begining = viewModel.Begining,
        //            Date = viewModel.Date,
        //            HoursCount = viewModel.HoursCount
        //        });

        //        if (seats.HasNoValue)
        //            continue;

        //        seats.Value.Sort((a,b)=>a.Number - b.Number);

        //        int seatCountInRow = 0;

        //        foreach(var seat in seats.Value)
        //        {
        //            if (seat.IsFree)
        //                seatCountInRow++;
        //            else
        //                seatCountInRow = 0;
        //            if(viewModel.Count == seatCountInRow)
        //            {
        //                resultList.Add(_mapper.Map<RoomDto>(room));
        //                rooms.Remove(room);
        //                break;
        //            }
        //        }
        //    }     
        //    return resultList;
        //}

        public async Task<Maybe<int>> GetFreeSeatsCount(Guid roomId, RoomFilterBL filter)
        {
            if (filter.HoursCount.HasNoValue || filter.Date.HasNoValue || filter.Begining.HasNoValue)
                return -1;
            var result = await _seatService.GetSeatsByRoomInRangeIdAsync(new SeatsGettingViewModel
            {
                Date = filter.Date.Value,
                Begining = filter.Begining.Value,
                RoomId = roomId,
                HoursCount = filter.HoursCount.Value
            });
            if (result.HasNoValue)
                return -1;
            return result.Value.Where(r=>r.IsFree).Count();
        }
    }
}
