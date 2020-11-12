using Api.Models;
using Api.Models.Music;
using Api.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class MusicService : IMusicService
    {
        private readonly IMapper _mapper;
        private readonly MusicRepository _startingRepository;

        public MusicService(string connectionString, IMapper mapper)
        {
            _mapper = mapper;
            _startingRepository = new MusicRepository(connectionString);
        }

        public MusicModelWrapper GetMusic()
        {
            var getMusic = _startingRepository.GetMusic();

            return _mapper.Map<MusicModelWrapper>(getMusic);
        }
    }
}
