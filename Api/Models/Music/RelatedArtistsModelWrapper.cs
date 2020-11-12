using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Music
{
    public class RelatedArtistsModelWrapper
    {
        [JsonProperty("drinks")]
        public List<RelatedArtistsModel> measureData { get; set; }
    }

}
