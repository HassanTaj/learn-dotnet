using LandonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LandonApi.Services
{
    public interface IOpeningService
    {
        Task<PagedResult<Opening>> GetOpeningsAsync(PagingOptions pagingOptions,CancellationToken cts);

        Task<IEnumerable<BookingRange>> GetConflictingSlots(
            Guid roomId,
            DateTimeOffset start,
            DateTimeOffset end);
    }
}
