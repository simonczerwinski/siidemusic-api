using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository.Spotify
{
    public interface ISpotifyRepository
    {
        SpotifyAccessTokenWrapper GetToken();
    }
}
