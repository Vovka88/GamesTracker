using GamesTracker.Core.Model;
using Multipage.Navigator;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace GamesTracker.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : UserControl
    {
        private List<GameData> matches;
        public HistoryWindow(List<GameData> matches)
        {
            InitializeComponent();
            this.matches = matches;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (GameData data in matches)
            {
                lv_matches.Items.Add(data);
            }
        }

        private void lv_matches_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (matches[lv_matches.SelectedIndex]._matchId != null) NavigatorObject.Switch(new DotaWindow(lv_matches.SelectedIndex, matches));
            else NavigatorObject.Switch(new CompetitiveWindow(lv_matches.SelectedIndex, matches));
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new AddGameWindow(matches));
        }
    }
}
