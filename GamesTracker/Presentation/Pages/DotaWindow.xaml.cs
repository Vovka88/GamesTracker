using GamesObserver.Data.Api;
using GamesObserver.Data.Jsons;
using GamesTracker.Core.Model;
using Multipage.Navigator;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GamesTracker.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for DotaWindow.xaml
    /// </summary>
    public partial class DotaWindow : UserControl
    {
        private string match_id;
        private int index;
        private RAM_API_ENGINE _engine;
        private DotaMatchStats _stats;
        private List<GameData> _matches;
        public DotaWindow(int _index, List<GameData> _matches)
        {
            InitializeComponent();
            this.match_id = _matches[_index]._matchId;
            _engine = new RAM_API_ENGINE();
            this._matches = _matches;
            _stats = new DotaMatchStats();
            index = _index;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _stats = JSONProvider.FromJsonTakeStatistic(_engine.GetMatchResults(match_id));
            int minutes = _stats._duration / 60, seconds = _stats._duration % 60;
            gamemode.Text = DotaInfo.FromJsonTakeModes(_stats._gamemode);
            duration.Text = $"{minutes}:{seconds}";
            victory.Text = _stats._win == true ? "Radiant wins!": "Dire wins!";
            radscore.Text = _stats._radiantScore.ToString();
            direscore.Text = _stats._direScore.ToString();

            for (int i = 0; i < (_matches[index]._PlayersCount/2); i++)
            {
                radiantTeam.Items.Add(_stats.players[i]);
            }
            for (int i = (_matches[index]._PlayersCount / 2); i < _matches[index]._PlayersCount; i++)
            {
                direTeam.Items.Add(_stats.players[i]);
            }
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new HistoryWindow(_matches));
        }
    }
}
