using Api.Models.Album;
using Api.Repository.Album;
using Api.Repository.Spotify;
using Api.Services.Spotify;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Album
{
    public class AlbumService : IAlbumService
    {
      
        private readonly IMapper _mapper;
        private readonly AlbumRepository _startingRepository;
        public AlbumService(string connectionString, IMapper mapper)
        {
            _mapper = mapper;
            _startingRepository = new AlbumRepository(connectionString);
        }

        public AlbumWrapper GetAlbum(string trackId)
        {
            var getMusic = _startingRepository.GetAlbum(trackId);

            return _mapper.Map<AlbumWrapper>(getMusic);
        }
    }
}
