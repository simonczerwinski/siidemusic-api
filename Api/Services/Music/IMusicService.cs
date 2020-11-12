using Api.Models;
using Api.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IMusicService
    {
        MusicModelWrapper GetMusic();
    }
}
