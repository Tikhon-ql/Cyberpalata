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
        private readonly ISeatService _seatService;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository repository, ISeatService seatService, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _seatService = seatService;
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

        public async Task<Result> AddBookingToRoom(Guid userId, BookingCreateRequest request)
        {
            if (request.Seats.Count == 0)
                return Result.Failure("Seats collection is empty");

            if ((request.Date - DateTime.Now).Days >= 14)
                return Result.Failure("Incorrect date: You can make a booking only on 2 weeks ahead");

            var room = await _repository.ReadAsync(request.RoomId);
            if (room.HasNoValue)
                return Result.Failure($"There aren't roo with id:{request.RoomId}");
            var dto = _mapper.Map<BookingDto>(request);

            dto.User.Id = userId;
            await _repository.AddBookingToRoomAsync(request.RoomId, _mapper.Map<Booking>(dto));
            return Result.Success();
        }

        public async Task<Maybe<List<RoomDto>>> SearchRooms(SearchRoomRequest request)
        {
            var rooms = await _repository.GetAll();
            if (rooms.HasNoValue)
                return Maybe.None;
            var resultList = new List<RoomDto>();
            foreach (var room in rooms.Value)
            {
                var seats = await _seatService.GetSeatsByRoomInRangeIdAsync(new SeatsGettingRequest
                {
                    RoomId = room.Id,
                    Begining = request.Begining,
                    Date = request.Date,
                    HoursCount = request.HoursCount
                });

                if (seats.HasNoValue)
                    continue;

                seats.Value.Sort((a,b)=>a.Number - b.Number);

                int seatCountInRow = 0;

                foreach(var seat in seats.Value)
                {
                    if (seat.IsFree)
                        seatCountInRow++;
                    else
                        seatCountInRow = 0;
                    if(request.Count == seatCountInRow)
                    {
                        resultList.Add(_mapper.Map<RoomDto>(room));
                        rooms.Value.Remove(room);
                        break;
                    }
                }
            }
            
            return resultList;
        }
    }
}
