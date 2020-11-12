using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Music
{
    public class AlbumModelWrapper
    {
        [JsonProperty("drinks")]
        public List<AlbumModel> AlbumData { get; set; }
    }

}
