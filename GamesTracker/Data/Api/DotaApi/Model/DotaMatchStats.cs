using System.Collections.Generic;

namespace GamesObserver.Data.Api
{
    internal class DotaMatchStats
    {
        public string _matchId { get; set; }
        public int _duration { get; set; }
        public int _radiantScore { get; set; }
        public int _direScore { get; set; }
        public int _gamemode{ get; set; } // Example: 22 - Allpick or 4 - Single draft
        public bool _win{ get; set; } // 0 - Diar win | 1 - Radiant win

        public List<Player> players { get; set; }

        public DotaMatchStats() 
        {
            
        }

        public DotaMatchStats(string _matchId, int _duration, int _radiantScore, int _direScore, int gamemode, bool _win)
        {
            this._matchId = _matchId;
            this._duration = _duration;
            this._radiantScore = _radiantScore;
            this._direScore = _direScore;
            this._gamemode = gamemode;
            this._win = _win;
            players = new List<Player>();
        }
    }
}
