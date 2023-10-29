using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GamesObserver.Data.Api
{
    sealed class JSONProvider
    {
        public static DotaMatchStats FromJsonTakeStatistic(string json)
        {
            DotaMatchStats stats = new DotaMatchStats();
            JObject keyValuePairs = JObject.Parse(json);
            stats._matchId = keyValuePairs["match_id"].ToObject<string>();
            stats._duration = keyValuePairs["duration"].ToObject<int>();
            stats._radiantScore = keyValuePairs["radiant_score"].ToObject<int>();
            stats._direScore = keyValuePairs["dire_score"].ToObject<int>();
            stats._gamemode = keyValuePairs["game_mode"].ToObject<int>();
            stats._win = keyValuePairs["radiant_win"].ToObject<bool>();
            IList<JToken> list = keyValuePairs["players"].Children().ToList();
            List<Player> players = new List<Player>();
            int c = 0;
            foreach (JToken token in list)
            {
                Player user = new Player();
                Console.WriteLine(token.ToString());
                user._heroId = token["hero_id"].ToObject<int>();
                user._kills = token["kills"].ToObject<int>();
                user._death = token["deaths"].ToObject<int>();
                user._assists = token["assists"].ToObject<int>();
                user._gpm = token["gold_per_min"].ToObject<int>();
                user._xpm = token["xp_per_min"].ToObject<int>();
                user._networth = token["net_worth"].ToObject<int>();
                user._heroDamage = token["hero_damage"].ToObject<int>();
                user._towerDamage = token["tower_damage"].ToObject<int>();
                players.Add(user);
            }
            stats.players = players;
            return stats;
        }
    }
}

//7393055841
