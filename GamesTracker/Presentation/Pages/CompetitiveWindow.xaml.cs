using GamesTracker.Core.Model;
using Multipage.Navigator;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GamesTracker.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for CompetitiveWindow.xaml
    /// </summary>
    public partial class CompetitiveWindow : UserControl
    {
        private GameData _data;
        private List<GameData> _matches;

        public CompetitiveWindow(int _index, List<GameData> _matches)
        {
            InitializeComponent();
            this._data = _matches[_index];
            this._matches = _matches;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gamename.Text = _data._Name;
            for (int i = 0; i < _data._PlayersCount; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = "Player";
                tb.FontSize = 16;
                tb.FontWeight = FontWeights.Regular;
                tb.Foreground = Brushes.White;
                if (i % 2 != 0) teamB.Children.Add(tb);
                else teamA.Children.Add(tb);
            }
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new HistoryWindow(_matches));
        }
    } 
}
