using Api.Models;
using Api.Repository.Spotify;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Spotify
{
    public class SpotifyService : ISpotifyService
    {

        private readonly IMapper _mapper;
        private readonly SpotifyRepository _startingRepository;

        public SpotifyService(string connectionString, IMapper mapper)
        {
            _mapper = mapper;
            _startingRepository = new SpotifyRepository(connectionString);
        }

        public SpotifyAccessTokenWrapper GetToken()
        {
            var getToken = _startingRepository.GetToken();

            return _mapper.Map<SpotifyAccessTokenWrapper>(getToken);
        }
    }
}
