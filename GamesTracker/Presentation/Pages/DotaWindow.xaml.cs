using GamesObserver.Data.Api;
using GamesObserver.Data.Jsons;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GamesTracker.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for DotaWindow.xaml
    /// </summary>
    public partial class DotaWindow : UserControl
    {
        private string match_id;
        private RAM_API_ENGINE _engine;
        private DotaMatchStats _stats;

        public DotaWindow(string match_id)
        {
            InitializeComponent();
            this.match_id = match_id;
            _engine = new RAM_API_ENGINE();
            _stats = new DotaMatchStats();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _stats = JSONProvider.FromJsonTakeStatistic(_engine.GetMatchResults(match_id));
            int minutes = _stats._duration / 60, seconds = _stats._duration % 60;
            gamemode.Text = _stats._gamemode.ToString();
            duration.Text = $"{minutes}:{seconds}";
            victory.Text = _stats._win == true ? "Radiant wins!": "Dire wins!";
            radscore.Text = _stats._radiantScore.ToString();
            direscore.Text = _stats._direScore.ToString();
        }
    }
}
