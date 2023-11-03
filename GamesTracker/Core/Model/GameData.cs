namespace GamesTracker.Core.Model
{
    public class GameData
    {
        public string _Name { get; set; }
        public int _PlayersCount { get; set; }
        public string _TeamA { get; set; }
        public int _PlayersInTeamA { get; set; }
        public string _TeamB { get; set; }
        public int _PlayersInTeamB { get; set; }

        public string _matchId { get; set; }   

        public GameData(string _Name, int _PlayersCount, string _TeamA, string _TeamB, string matchId = null)
        {
            this._Name = _Name;
            this._PlayersCount = _PlayersCount;
            this._TeamA = _TeamA;
            this._TeamB = _TeamB;
            this._matchId = matchId;

            if (_PlayersCount % 2 == 0) _PlayersInTeamA = _PlayersCount / 2;
            else _PlayersInTeamA = (_PlayersCount / 2) + 1;
            _PlayersInTeamB = _PlayersCount / 2;
            _matchId = matchId;
        }
    }
}
