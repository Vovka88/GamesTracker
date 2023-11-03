using GamesTracker.Core.Model;
using GamesTracker.Presentation.Pages;
using Multipage.Navigator;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GamesTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<GameData> list = new List<GameData>();
        public MainWindow()
        {
            InitializeComponent();
            list.Add(new GameData("Dota 2", 10, "TeamA", "TeamB"));
            list.Add(new GameData("CSGO", 9, "TeamA", "TeamB"));
            NavigatorObject.pageSwitcher = this;
            //NavigatorObject.Switch(new CompetitiveWindow(new Core.Model.GameData("Dota 2", 10, "TeamA", "TeamB")));
            NavigatorObject.Switch(new HistoryWindow(list));
            //NavigatorObject.Switch(new DotaWindow("7393055841", list));
        }

        public Action CloseAction { get; set; }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            INavigator s = nextPage as INavigator;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not INavigator! " + nextPage.Name.ToString());
        }
    }
}
//4

//7393055841