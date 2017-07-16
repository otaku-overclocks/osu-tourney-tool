using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BracketStage
    {
        [JsonProperty(PropertyName = "id")]
        public int StageId{get;set;}
        [JsonProperty(PropertyName = "matches")]
        public List<Match> Matches{get;set;}
        [JsonProperty(PropertyName = "mappool_id")]
        public int MappoolId{get;set;}
        [JsonProperty(PropertyName = "round_until_grandfinals")]
        public int RoundsUntilGrandfinals{get;set;}
        [JsonProperty(PropertyName = "loser_bracket")]
        public bool? LoserBracket{get;set;}
    }
}
