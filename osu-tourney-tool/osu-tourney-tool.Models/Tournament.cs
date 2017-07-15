using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Tournament
    {
        // enums
        public enum Gamemodes
        {
            Standard = 0,
            Taiko = 1,
            CatchTheBeat = 2,
            Mania = 3
        }

        public enum ScoringModes
        {
            ScoreV1 = 0,
            Accuracy,
            Combo,
            ScoreV2
        }

        public enum TeamModes
        {
            HeadToHead = 0,
            TagCoop = 1,
            TeamVS = 2,
            TagTeamVS = 3
        }

        public enum RangeTypes
        {
            Rank = 0,
            Performance
        }

        // properties
        [JsonProperty(PropertyName = "id")]
        public uint? TournamentId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name{get;set;}
        [JsonProperty(PropertyName = "short_name")]
        public string ShortName{get;set;}
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription{get;set;}
        [JsonProperty(PropertyName = "description")]
        public string Description{get;set;}
        [JsonProperty(PropertyName = "banner_url")]
        public string BannerURL{get;set;}
        [JsonProperty(PropertyName = "gamemode")]
        public Gamemodes Gamemode{get;set;}
        [JsonProperty(PropertyName = "scoring_mode")]
        public ScoringModes ScoringMode{get;set;}
        [JsonProperty(PropertyName = "team_mode")]
        public TeamModes TeamMode{get;set;}
        [JsonProperty(PropertyName = "range_type")]
        public RangeTypes RangeType{get;set;}
        [JsonProperty(PropertyName = "min_skill")]
        public int MinSkill{get;set;}
        [JsonProperty(PropertyName = "max_skill")]
        public int MaxSkill{get;set;}
        [JsonProperty(PropertyName = "teams")]
        public List<Team> Teams{get;set;}
        [JsonProperty(PropertyName = "players")]
        public List<Player> Players{get;set;}
        [JsonProperty(PropertyName = "max_teams")]
        public int MaxTeams{get;set;}
        [JsonProperty(PropertyName = "group_stage")]
        public GroupStage GroupStage{get;set;}
        [JsonProperty(PropertyName = "brackets")]
        public List<BracketStage> Brackets{get;set;}
        [JsonProperty(PropertyName = "staff")]
        public List<StaffMember> Staff{get;set;}
        [JsonProperty(PropertyName = "current_stage")]
        public int CurrentStage{get;set;}
        [JsonProperty(PropertyName = "stream_link")]
        public string StreamLink {get;set;}
    }
}
