namespace GamesObserver.Data.Api
{
    internal class Player
    {
        public int _heroId { get; set; }
        public int _kills { get; set; }
        public int _death { get; set; }
        public int _assists { get; set; }
        public int _gpm { get; set; }
        public int _xpm { get; set; }
        public int _networth { get; set; }
        public int _heroDamage { get; set; }
        public int _towerDamage { get; set; }

        public Player()
        {

        }

        public Player(int heroId, int kills, int death, int assists, int gpm, int xpm, int networth, int heroDamage, int towerDamage)
        {
            _heroId = heroId;
            _kills = kills;
            _death = death;
            _assists = assists;
            _gpm = gpm;
            _xpm = xpm;
            _networth = networth;
            _heroDamage = heroDamage;
            _towerDamage = towerDamage;
        }
    }
}
