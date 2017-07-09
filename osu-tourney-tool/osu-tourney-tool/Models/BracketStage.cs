using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class BracketStage
    {
        [JsonProperty(PropertyName = "id")]
        internal int StageID{get;set;}
        [JsonProperty(PropertyName = "matches")]
        internal List<Match> Matches{get;set;}
        [JsonProperty(PropertyName = "mappool_id")]
        internal int MappoolID{get;set;}
        [JsonProperty(PropertyName = "round_until_grandfinals")]
        internal int RoundsUntilGrandfinals{get;set;}
        [JsonProperty(PropertyName = "loser_bracket")]
        internal bool? LoserBracket{get;set;}
    }
}
