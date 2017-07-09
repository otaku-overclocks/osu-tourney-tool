using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class Player
    {
        [JsonProperty(PropertyName = "username")]
        internal string Username{get;set;}
        [JsonProperty(PropertyName = "user_id")]
        internal int UserID{get;set;}
        [JsonProperty(PropertyName = "rank")]
        internal int Rank{get;set;}
        [JsonProperty(PropertyName = "performance")]
        internal int Performance{get;set;}
    }
}
