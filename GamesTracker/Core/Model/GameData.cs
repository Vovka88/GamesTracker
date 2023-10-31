using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTracker.Core.Model
{
    public class GameData
    {
        public string _Name { get; set; }
        public int _PlayersCount { get; set; }

        public GameData(string _Name, int _PlayersCount) {
            this._Name = _Name;
            this._PlayersCount = _PlayersCount;
        }
    }
}
