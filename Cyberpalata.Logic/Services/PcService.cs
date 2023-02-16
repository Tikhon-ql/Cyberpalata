using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Devices;

namespace Cyberpalata.Logic.Services
{
    public class PcService : IPcService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public PcService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<Maybe<PcDto>> GetByGamingRoomId(Guid roomId)
        {
            var room = await _roomRepository.ReadAsync(roomId);
            if (room.HasNoValue)
                return Maybe.None;
            var pc = room.Value.Pc;
            return _mapper.Map<PcDto>(pc);
        }   
    }
}
