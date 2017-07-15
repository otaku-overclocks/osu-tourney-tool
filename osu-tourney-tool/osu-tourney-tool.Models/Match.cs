using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Match
    {
        [JsonProperty(PropertyName = "id")]
        public int MatchID{get;set;}
        [JsonProperty(PropertyName = "schedule")]
        public DateTime? Schedule{get;set;}
        [JsonProperty(PropertyName = "red_team_id")]
        public int? RedTeamID{get;set;}
        [JsonProperty(PropertyName = "red_team_score")]
        public int? RedTeamScore{get;set;}
        [JsonProperty(PropertyName = "blue_team_id")]
        public int? BlueTeamID{get;set;}
        [JsonProperty(PropertyName = "blue_team_score")]
        public int? BlueTeamScore{get;set;}
    }
}
