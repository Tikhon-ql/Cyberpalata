using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IApiUserRepository _userRepository;
        private readonly IBookingFilter _filter;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository repository,
            IApiUserRepository userRepository, 
            IMapper mapper, IBookingFilter filter)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _filter = filter;
        }
        public async Task<Maybe<BookingDto>> ReadAsync(Guid id)
        {
            var booking = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<BookingDto>>(booking);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var result = await SearchAsync(id);
            if (result.IsFailure)
                return Result.Failure(result.Error);

            _repository.Delete(_mapper.Map<Booking>(result.Value));
            return Result.Success();
        }
        public async Task<Result<BookingDto>> SearchAsync(Guid id)
        {
            var booking = await _repository.ReadAsync(id);
            if (!booking.HasValue)
                return Result.Failure<BookingDto>($"Booking with id {id} doesn't exist");
            return Result.Success(_mapper.Map<BookingDto>(booking.Value));
        }

        public async Task<PagedList<BookingDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<BookingDto>>(list);
        }

        public async Task<Maybe<List<BookingDto>>> GetBookingsByUserAsync(Guid userId)
        {
            var user = await _userRepository.ReadAsync(userId);
            if (user.HasNoValue)
                return Maybe.None;
            var bookings = user.Value.Bookings;
            return _mapper.Map<List<BookingDto>>(bookings).AsMaybe();
        }

        public async Task<PagedList<BookingDto>> GetPagedListAsync(int pageNumber, Guid userId)
        {
            var list = await _repository.GetPagedListAsync(pageNumber, userId);
            return _mapper.Map<PagedList<BookingDto>>(list);
        }
    }
}
