using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_tourney_tool.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class Tournament
    {
        // enums
        internal enum Gamemodes
        {
            Standard = 0,
            Taiko = 1,
            CatchTheBeat = 2,
            Mania = 3
        }

        internal enum ScoringModes
        {
            ScoreV1 = 0,
            Accuracy,
            Combo,
            ScoreV2
        }

        internal enum TeamModes
        {
            HeadToHead = 0,
            TagCoop = 1,
            TeamVS = 2,
            TagTeamVS = 3
        }

        internal enum RangeTypes
        {
            Rank = 0,
            Performance
        }

        // properties
        [JsonProperty(PropertyName = "id")]
        internal uint? TournamentId { get; set; }
        [JsonProperty(PropertyName = "name")]
        internal string Name{get;set;}
        [JsonProperty(PropertyName = "short_name")]
        internal string ShortName{get;set;}
        [JsonProperty(PropertyName = "short_description")]
        internal string ShortDescription{get;set;}
        [JsonProperty(PropertyName = "description")]
        internal string Description{get;set;}
        [JsonProperty(PropertyName = "banner_url")]
        internal string BannerURL{get;set;}
        [JsonProperty(PropertyName = "gamemode")]
        internal Gamemodes Gamemode{get;set;}
        [JsonProperty(PropertyName = "scoring_mode")]
        internal ScoringModes ScoringMode{get;set;}
        [JsonProperty(PropertyName = "team_mode")]
        internal TeamModes TeamMode{get;set;}
        [JsonProperty(PropertyName = "range_type")]
        internal RangeTypes RangeType{get;set;}
        [JsonProperty(PropertyName = "min_skill")]
        internal int MinSkill{get;set;}
        [JsonProperty(PropertyName = "max_skill")]
        internal int MaxSkill{get;set;}
        [JsonProperty(PropertyName = "teams")]
        internal List<Team> Teams{get;set;}
        [JsonProperty(PropertyName = "players")]
        internal List<Player> Players{get;set;}
        [JsonProperty(PropertyName = "max_teams")]
        internal int MaxTeams{get;set;}
        [JsonProperty(PropertyName = "group_stage")]
        internal GroupStage GroupStage{get;set;}
        [JsonProperty(PropertyName = "brackets")]
        internal List<BracketStage> Brackets{get;set;}
        [JsonProperty(PropertyName = "staff")]
        internal List<StaffMember> Staff{get;set;}
        [JsonProperty(PropertyName = "current_stage")]
        internal int CurrentStage{get;set;}
    }
}
