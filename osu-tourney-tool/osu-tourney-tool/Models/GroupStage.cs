using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class GroupStage
    {
        [JsonProperty(PropertyName = "id")]
        internal int StageID{get;set;}
        [JsonProperty(PropertyName = "groups")]
        internal List<Group> Groups{get;set;}
        [JsonProperty(PropertyName = "mappool_id")]
        internal int MappoolID{get;set;}
    }
}
