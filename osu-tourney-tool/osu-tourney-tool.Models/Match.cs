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
        public int MatchId{get;set;}
        [JsonProperty(PropertyName = "schedule")]
        public DateTime? Schedule{get;set;}
        [JsonProperty(PropertyName = "red_team_id")]
        public int? RedTeamId{get;set;}
        [JsonProperty(PropertyName = "red_team_score")]
        public int? RedTeamScore{get;set;}
        [JsonProperty(PropertyName = "blue_team_id")]
        public int? BlueTeamId{get;set;}
        [JsonProperty(PropertyName = "blue_team_score")]
        public int? BlueTeamScore{get;set;}
    }
}
