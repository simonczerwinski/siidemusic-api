using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Album
{
    public class AlbumWrapper
    {
        [JsonProperty("album")]
        public List<Album> AlbumData { get; set; }
    }
}
