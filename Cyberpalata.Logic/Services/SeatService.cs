using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class SeatService : ISeatService
    {
        private readonly ISeatRepository _repository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public SeatService(ISeatRepository repository, IRoomRepository roomRepository, IMapper mapper)
        {
            _repository = repository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SeatDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Seat>(entity));
        }

        public async Task CreateRangeAsync(List<SeatDto> seats)
        {
            await _repository.CreateRangeAsync(_mapper.Map<List<Seat>>(seats));
        }

        public async Task<Maybe<SeatDto>> ReadAsync(Guid id)
        {
            var seat = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<SeatDto>>(seat);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var result = await SearchAsync(id);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            _repository.Delete(_mapper.Map<Seat>(result.Value));

            return Result.Success();
        }
        public async Task<Result<SeatDto>> SearchAsync(Guid id)
        {
            var seat = await _repository.ReadAsync(id);
            if (!seat.HasValue)
                return Result.Failure<SeatDto>($"Seat with id {id} doesn't exist");
            return Result.Success(_mapper.Map<SeatDto>(seat.Value));
        }

        public Task<PagedList<SeatDto>> GetPagedListAsync(int pageNumber)
        {
            throw new NotImplementedException();
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
            if (room.HasNoValue)//////?????????
                return Maybe.None;/////????????????
            var list = room.Value.Seats;
            var resultSeats = _mapper.Map<List<SeatDto>>(room.Value.Seats);
            var bookings = room.Value.Bookings
                .Where(b => b.Date > DateTime.Now 
                && (b.Date == request.Date 
                && ((b.Begining <= request.Begining && b.Ending >= request.Begining) 
                || (b.Begining <= request.Ending && request.Begining <= b.Begining)))).ToList();
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
