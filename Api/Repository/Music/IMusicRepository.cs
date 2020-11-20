using Api.Models;
using Api.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public interface IMusicRepository
    {
        MusicModelWrapper GetMusic();
        IList<MusicModelWrapper> SaveMusic();
    }
}
