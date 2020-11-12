using Api.Models.Music;
using Api.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.MusicList
{
    public class MusicListService : IMusicListService
    {
        private readonly IMapper _mapper;
        private readonly MusicRepository _startingRepository;

        public MusicListService(string connectionString, IMapper mapper)
        {
            _mapper = mapper;
            _startingRepository = new MusicRepository(connectionString);
        }

        public IList<MusicModelWrapper> SaveMusic()
        {
            var saveMusic = _startingRepository.SaveMusic();

            return _mapper.Map<IList<MusicModelWrapper>>(saveMusic);
        }
    }
}
