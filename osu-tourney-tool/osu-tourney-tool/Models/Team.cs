using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class Team
    {
        [JsonProperty(PropertyName = "id")]
        internal int TeamID{get;set;}
        [JsonProperty(PropertyName = "name")]
        internal string Name{get;set;}

        [JsonProperty(PropertyName = "players")]
        internal List<int> PlayerIDs { get; set; } = new List<int>();
    }
}
