using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Player
    {
        [JsonProperty(PropertyName = "username")]
        public string Username{get;set;}
        [JsonProperty(PropertyName = "user_id")]
        public int UserID{get;set;}
        [JsonProperty(PropertyName = "rank")]
        public int Rank{get;set;}
        [JsonProperty(PropertyName = "performance")]
        public int Performance{get;set;}
    }
}
