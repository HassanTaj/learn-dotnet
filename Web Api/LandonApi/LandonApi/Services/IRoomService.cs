using LandonApi.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LandonApi.Services {
    public interface IRoomService {
        Task<Room> GetRoomAsync(Guid id, CancellationToken cts);
        //Task<IEnumerable<Room>> GetRoomsAsync(PagingOptions pagingOptions,
        //    SortOptions<Room, RoomEntity> sortOptions,
        //    SearchOptions<Room, RoomEntity> searchOptions,
        //    CancellationToken cts);

        Task<PagedResult<Room>> GetRoomsAsync(PagingOptions pagingOptions,
    SortOptions<Room, RoomEntity> sortOptions,
    SearchOptions<Room, RoomEntity> searchOptions,
    CancellationToken cts);
    }
}
