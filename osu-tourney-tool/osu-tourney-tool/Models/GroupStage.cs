using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GroupStage
    {
        [JsonProperty(PropertyName = "id")]
        public int StageID{get;set;}
        [JsonProperty(PropertyName = "groups")]
        public List<Group> Groups{get;set;}
        [JsonProperty(PropertyName = "mappool_id")]
        public int MappoolID{get;set;}
    }
}
