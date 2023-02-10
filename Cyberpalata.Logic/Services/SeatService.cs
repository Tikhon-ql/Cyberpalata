using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Seats;

namespace Cyberpalata.Logic.Services
{
    internal class SeatService : ISeatService
    {
        private readonly ISeatRepository _repository;
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public SeatService(ISeatRepository repository, IRoomRepository roomRepository, IBookingRepository bookingRepository, IMapper mapper)
        {
            _repository = repository;
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }


        public async Task<Maybe<List<SeatDto>>> GetSeatsByRoomIdAsync(Guid roomId)
        {
            var room = await _roomRepository.ReadAsync(roomId);
            if (room.HasNoValue)
                return Maybe.None;
            var list = room.Value.Seats;
            var resultSeats = _mapper.Map<List<SeatDto>>(room.Value.Seats);
            var bookings = room.Value.Bookings.Where(b => b.Date > DateTime.Now).ToList();
            foreach (var seat in resultSeats)
            {
                var isSeatFree = bookings.FirstOrDefault(b => b.Seats.FirstOrDefault(s => s.Id == seat.Id) != null) == null;
                if (isSeatFree)
                {
                    seat.IsFree = true;
                }
            }
            return resultSeats;
        }

        public async Task<Maybe<List<SeatDto>>> GetSeatsByRoomInRangeIdAsync(SeatsGettingRequest request)
        {
            var room = await _roomRepository.ReadAsync(request.RoomId);
            if (room.HasNoValue)
                return Maybe.None;

            var roomSeats = room.Value.Seats;
            var resultSeats = _mapper.Map<List<SeatDto>>(room.Value.Seats);

            var actualRoomBookings = await _bookingRepository.GetActualBookingsByRoomId(request.RoomId);
            if (actualRoomBookings.HasNoValue)
                return resultSeats;

            var bookings = actualRoomBookings.Value
                .Where(b => (b.Date == request.Date
                && ((request.Begining <= b.Begining 
                    && request.Date.Add(request.Begining).AddHours(request.HoursCount) > b.Date.Add(b.Begining)) 
                || (b.Begining <= request.Begining
                    && request.Date.Add(request.Begining) < b.Date.Add(b.Begining).AddHours(b.HoursCount))))).ToList();
            foreach (var seat in resultSeats)
            {
                var isSeatFree = bookings.FirstOrDefault(b => b.Seats.FirstOrDefault(s => s.Id == seat.Id) != null) == null;
                if (isSeatFree)
                {
                    seat.IsFree = true;
                }
            }
            return resultSeats;
        }
    }
}
