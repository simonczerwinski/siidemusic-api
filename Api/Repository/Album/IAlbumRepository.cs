using Api.Models.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository.Album
{
    public interface IAlbumRepository
    {
        AlbumWrapper GetAlbum(string trackId);
    }
}
