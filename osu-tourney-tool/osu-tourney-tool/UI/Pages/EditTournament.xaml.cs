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
    public partial class EditTournament : Page
    {
        public bool IsNewTournament;
        private Dictionary<int, string> _roles = new Dictionary<int, string>();


        public EditTournament()
        {
            InitializeComponent();
            int i = 0;
            foreach (ComboBoxItem item in StaffRoleDropdown.Items)
            {
                _roles.Add(i, Convert.ToString(item.Content));
                i++;
            }
            Console.WriteLine("Handy breakpoint in here");
        }

        private int _PlayerID = 1;
        private int _TeamID = 1;
        private List<Player> _players = new List<Player>();
        private List<Team> _teams = new List<Team>();

        private void CreateTourneyButton_Click(object sender, RoutedEventArgs e)
        {
            Tournament tourney = new Tournament
            {
                Name = NameBox.Text,
                ShortName = ShortNameBox.Text,
                ShortDescription = ShortDescBox.Text,
                Description = LongDescBox.Text,
                BannerURL = BannerBox.Text,
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
            List<StaffMember> staff = new List<StaffMember>();
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
            StaffMember member = new StaffMember {Username = StaffUsernameBox.Text};
            member.SetRole(StaffRoleDropdown.SelectedIndex, _roles[StaffRoleDropdown.SelectedIndex]);
            StaffListView.Items.Add(member);
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (VsModeDropdown.SelectedIndex == 0)
            {
                _players.Add(new Player {Username = UserNamesBox.Text, UserID = _PlayerID});
                _PlayerID++;
            }
            else
            {
                Team team = new Team();
                List<Player> players = new List<Player>();
                string[] usernames = UserNamesBox.Text.Split('\\');
                foreach (string name in usernames)
                {
                    players.Add(new Player {Username = name, UserID = _PlayerID});
                    _PlayerID++;
                }
                foreach (Player player in players)
                {
                    _players.Add(player);
                    team.PlayerIDs.Add(player.UserID);
                }
                team.Name = TeamNameBox.Text;
                _teams.Add(team);
                _TeamID++;
            }
        }

        private void TeamSizeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsInitialized is true)
            {
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
}