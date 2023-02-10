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

        public async Task<PagedList<BookingDto>> GetPagedListAsync(int pageNumber, Guid userId)
        {
            var list = await _repository.GetPagedListAsync(pageNumber, userId);
            return _mapper.Map<PagedList<BookingDto>>(list);
        }
    }
}
