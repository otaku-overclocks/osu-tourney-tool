using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using osu_tourney_tool.Models;
using Newtonsoft.Json;

namespace osu_tourney_tool.UI.Pages
{
    /// <summary>
    /// Logique d'interaction pour EditTournament.xaml
    /// </summary>
    public partial class EditTournament : BasePage
    {
        public bool IsNewTournament;
        private readonly Dictionary<int, string> _roles = new Dictionary<int, string>();


        public EditTournament()
        {
            InitializeComponent();
            var i = 0;
            foreach (ComboBoxItem item in StaffRoleDropdown.Items)
            {
                _roles.Add(i, Convert.ToString(item.Content));
                i++;
            }
        }

        private int _playerId = 1;
        private int _teamId = 1;
        private readonly List<Player> _players = new List<Player>();
        private readonly List<Team> _teams = new List<Team>();

        private void CreateTourneyButton_Click(object sender, RoutedEventArgs e)
        {
            var tourney = new Tournament
            {
                Name = NameBox.Text,
                ShortName = ShortNameBox.Text,
                ShortDescription = ShortDescBox.Text,
                Description = LongDescBox.Text,
                BannerUrl = BannerBox.Text,
                Gamemode = (Tournament.Gamemodes) GamemodeDropdown.SelectedIndex,
                ScoringMode = (Tournament.ScoringModes) ScoringDropdown.SelectedIndex,
                TeamMode = (Tournament.TeamModes) TeamModeDropdown.SelectedIndex,
                // range type is radio
                MinSkill = Convert.ToInt32(MinRangeBox.Text),
                MaxSkill = Convert.ToInt32(MaxRangeBox.Text),
                // nothing yet for teams and players, better design that soon!
                MaxTeams = Convert.ToInt32(MaxTeamsBox.Text)
            };
            if (RankRangeRadio.IsChecked == true)
            {
                tourney.RangeType = Tournament.RangeTypes.Rank;
            }
            else if (PerformanceRangeRadio.IsChecked == true)
            {
                tourney.RangeType = Tournament.RangeTypes.Performance;
            }
            var staff = new List<StaffMember>();
            foreach (StaffMember member in StaffListView.Items)
            {
                staff.Add(member);
            }
            tourney.Staff = staff;
            tourney.Players = _players;
            tourney.Teams = _teams;
            MessageBox.Show(JsonConvert.SerializeObject(tourney));
            Console.WriteLine(JsonConvert.SerializeObject(tourney));
        }

        private void AddStaffButton_Click(object sender, RoutedEventArgs e)
        {
            var member = new StaffMember {Username = StaffUsernameBox.Text};
            member.SetRole(StaffRoleDropdown.SelectedIndex, _roles[StaffRoleDropdown.SelectedIndex]);
            StaffListView.Items.Add(member);
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (VsModeDropdown.SelectedIndex == 0)
            {
                _players.Add(new Player {Username = UserNamesBox.Text, UserId = _playerId});
                _playerId++;
            }
            else
            {
                var team = new Team();
                var players = new List<Player>();
                var usernames = UserNamesBox.Text.Split('\\');
                foreach (var name in usernames)
                {
                    players.Add(new Player {Username = name, UserId = _playerId});
                    _playerId++;
                }
                foreach (var player in players)
                {
                    _players.Add(player);
                    team.PlayerIDs.Add(player.UserId);
                }
                team.Name = TeamNameBox.Text;
                _teams.Add(team);
                _teamId++;
            }
        }

        private void TeamSizeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(IsInitialized is true)) return;
            if (VsModeDropdown.SelectedIndex == 0)
            {
                TeamNameLabel.IsEnabled = false;
                TeamNameBox.IsEnabled = false;
            }
            else
            {
                TeamNameLabel.IsEnabled = true;
                TeamNameBox.IsEnabled = true;
            }
        }
    }
}