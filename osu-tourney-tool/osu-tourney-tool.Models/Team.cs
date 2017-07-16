using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Team
    {
        [JsonProperty(PropertyName = "id")]
        public int TeamId{get;set;}
        [JsonProperty(PropertyName = "name")]
        public string Name{get;set;}

        [JsonProperty(PropertyName = "players")]
        public List<int> PlayerIDs { get; set; } = new List<int>();
    }
}
