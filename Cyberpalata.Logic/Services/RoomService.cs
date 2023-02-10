using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Room;
using Cyberpalata.Logic.Models.Seats;

namespace Cyberpalata.Logic.Services
{
    internal class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IBookingFilter _bookingFilter;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository repository, IMapper mapper, IBookingFilter bookingFilter)
        {
            _repository = repository;
            _mapper = mapper;
            _bookingFilter = bookingFilter;
        }

        public async Task CreateAsync(RoomDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Room>(entity));
        }

        public async Task<Maybe<RoomDto>> ReadAsync(Guid id)
        {
            var room = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<RoomDto>>(room);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var res = await SearchAsync(id);

            if (res.IsFailure)
                return Result.Failure(res.Error);

            _repository.Delete(_mapper.Map<Room>(res.Value));

            return Result.Success();
        }

        public async Task<Result<RoomDto>> SearchAsync(Guid id)
        {
            var room = await _repository.ReadAsync(id);

            if (!room.HasValue)
                return Result.Failure<RoomDto>($"Room with id {id} doesn't exist");

            return Result.Success(_mapper.Map<RoomDto>(room.Value));
        }

        public async Task<PagedList<RoomDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<RoomDto>>(list);
        }

        public async Task<PagedList<RoomDto>> GetPagedListAsync(int pageNumber, RoomType type)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<RoomDto>>(list);
        }

        public async Task<PagedList<RoomDto>> GetVipRoomsAsync(int pageNumber, RoomType type)
        {
            var list = await _repository.GetVipRoomsAsync(pageNumber, type);
            return _mapper.Map<PagedList<RoomDto>>(list);
        }

        public async Task<PagedList<RoomDto>> GetCommonRoomsAsync(int pageNumber, RoomType type)
        {
            var list = await _repository.GetCommonRoomsAsync(pageNumber, type);
            return _mapper.Map<PagedList<RoomDto>>(list);
        }

        public async Task<Result> AddBookingToRoom(Guid userId,BookingCreateRequest request)
        {
            if (request.Seats.Count == 0)
                return Result.Failure("Seats collection is empty");

            if((request.Date - DateTime.Now).Days >= 14)
                return Result.Failure("Incorrect date");

            var room = await _repository.ReadAsync(request.RoomId);
            if (room.HasNoValue)
                return Result.Failure($"There aren't roo with id:{request.RoomId}");
            var dto = _mapper.Map<BookingDto>(request);

            if (!_bookingFilter.IsValid(dto))
                return Result.Failure("Data is invalid.");

            dto.User.Id = userId;
            await _repository.AddBookingToRoomAsync(request.RoomId, _mapper.Map<Booking>(dto));
            return Result.Success();
        }

        //public async Task<Maybe<List<SeatDto>>> GetRoomFreeSeats(Guid roomId)
        //{
        //    var list = await _repository.GetRoomFreeSeats(roomId);
        //    return _mapper.Map<Maybe<List<SeatDto>>>(list);
        //}
    }
}
