using Api.Models.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Album
{
    public interface IAlbumService
    {
   
        AlbumWrapper GetAlbum(string trackId);
    }
}
