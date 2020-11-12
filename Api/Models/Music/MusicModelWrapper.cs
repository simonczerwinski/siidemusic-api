using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Music
{
    public class MusicModelWrapper
    {
        [JsonProperty("drinks")]
        public List<MusicModel> MusicData { get; set; }
    }

}
