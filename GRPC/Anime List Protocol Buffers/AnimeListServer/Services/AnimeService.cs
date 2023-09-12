using AnimeListServer.Protos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeListServer.Services {
    public class AnimeService : Anime.AnimeBase {
        public override Task<GetAnimeListResponse> GetAnimeList(GetAnimeListRequest request, ServerCallContext context) {
            return base.GetAnimeList(request, context);
        }
    }
}
