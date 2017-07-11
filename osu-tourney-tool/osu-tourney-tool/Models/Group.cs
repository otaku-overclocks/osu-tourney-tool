using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Group
    {
        [JsonProperty(PropertyName = "id")]
        public int GroupID{get;set;}
        [JsonProperty(PropertyName = "team_ids")]
        public List<int> TeamIDList{get;set;}
        [JsonProperty(PropertyName = "matches")]
        public List<Match> Matches{get;set;}
    }
}
