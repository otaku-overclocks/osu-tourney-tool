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
        public int UserId{get;set;}
        [JsonProperty(PropertyName = "role")]
        public int RoleId{get;set;}

        // non json-ed properties
        // also temporary.
        public string Role{get;set;}

        public void SetRole(int roleId, string roleName)
        {
            RoleId = roleId;
            Role = roleName;
        }
    }
}
