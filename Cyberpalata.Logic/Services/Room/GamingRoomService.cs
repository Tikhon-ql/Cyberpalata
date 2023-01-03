using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces.Room;
using Cyberpalata.DataProvider.Models.Rooms;
using Cyberpalata.Logic.Interfaces.Room;
using Cyberpalata.Logic.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services.Room
{
    internal class GamingRoomService : RoomService, IGamingRoomService
    {
        private readonly IGamingRoomRepository _gamingRoomRepository;
        private readonly IMapper _mapper;

        public GamingRoomService(IGamingRoomRepository repository, IMapper mapper) : base(repository)
        {
            _gamingRoomRepository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(GamingRoomDto entity)
        {
            await _gamingRoomRepository.CreateAsync(_mapper.Map<GamingRoom>(entity));
        }
        public async Task<GamingRoomDto> ReadAsync(Guid id)
        {
            return _mapper.Map<GamingRoomDto>(await _gamingRoomRepository.ReadAsync(id));
        }
        public Task UpdateAsync(GamingRoomDto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<GamingRoomDto>> GetPagedListAsync(int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
