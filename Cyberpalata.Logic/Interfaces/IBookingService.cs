﻿using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IBookingService
    {
        Task CreateAsync(BookingCreateRequest request);
        Task<Maybe<BookingDto>> ReadAsync(Guid id);
        Task<Result> DeleteAsync(Guid id);
        Task<Result<BookingDto>> SearchAsync(Guid id);
        Task<PagedList<BookingDto>> GetPagedListAsync(int pageNumber);
        Task<Maybe<List<BookingDto>>> GetBookingsByUserAsync(Guid userId);
    }
}
