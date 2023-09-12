using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LandonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LandonApi.Services {
    public class DefaultRoomService : IRoomService {
        private readonly HotelApiContext _ctx;
        private readonly IMapper _mapper;
        public DefaultRoomService(HotelApiContext ctx,IMapper mapper) {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<Room> GetRoomAsync(Guid id, CancellationToken cts) {
            var ent = await _ctx.Rooms.SingleOrDefaultAsync(r => r.Id == id , cts);
            if (ent == null) return null;

            return _mapper.Map<Room>(ent);
        }

        public async Task<PagedResult<Room>> GetRoomsAsync(PagingOptions pagingOptions, SortOptions<Room, RoomEntity> sortOptions, SearchOptions<Room, RoomEntity> searchOptions, CancellationToken cts) {
            IQueryable<RoomEntity> query = _ctx.Rooms;

            query = searchOptions.Apply(query);
            query = sortOptions.Apply(query);
            var size = await query.CountAsync(cts);

            var items = await query
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value)
                .ProjectTo<Room>()
                .ToArrayAsync(cts);

            return new PagedResult<Room> {
                Items = items,
                TotalSize = size
            };
        }
    }
}
