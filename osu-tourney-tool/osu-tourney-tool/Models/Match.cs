using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class Match
    {
        [JsonProperty(PropertyName = "id")]
        internal int MatchID{get;set;}
        [JsonProperty(PropertyName = "schedule")]
        internal DateTime? Schedule{get;set;}
        [JsonProperty(PropertyName = "red_team_id")]
        internal int? RedTeamID{get;set;}
        [JsonProperty(PropertyName = "red_team_score")]
        internal int? RedTeamScore{get;set;}
        [JsonProperty(PropertyName = "blue_team_id")]
        internal int? BlueTeamID{get;set;}
        [JsonProperty(PropertyName = "blue_team_score")]
        internal int? BlueTeamScore{get;set;}
    }
}
