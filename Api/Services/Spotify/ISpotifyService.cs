﻿using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Spotify
{
    public interface ISpotifyService
    {

        SpotifyAccessTokenWrapper GetToken();
    }
}
