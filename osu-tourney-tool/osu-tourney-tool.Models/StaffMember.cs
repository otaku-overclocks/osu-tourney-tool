using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class StaffMember
    {
        [JsonProperty(PropertyName = "username")]
        public string Username{get;set;}
        [JsonProperty(PropertyName = "user_id")]
        public int UserID{get;set;}
        [JsonProperty(PropertyName = "role")]
        public int RoleID{get;set;}

        // non json-ed properties
        // also temporary.
        public string Role{get;set;}

        public void SetRole(int role_id, string role_name)
        {
            RoleID = role_id;
            Role = role_name;
        }
    }
}
