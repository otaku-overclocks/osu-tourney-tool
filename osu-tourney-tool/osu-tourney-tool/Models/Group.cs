using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class Group
    {
        [JsonProperty(PropertyName = "id")]
        internal int GroupID{get;set;}
        [JsonProperty(PropertyName = "team_ids")]
        internal List<int> TeamIDList{get;set;}
        [JsonProperty(PropertyName = "matches")]
        internal List<Match> Matches{get;set;}
    }
}
