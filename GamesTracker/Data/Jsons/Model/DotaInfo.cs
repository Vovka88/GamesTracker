using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GamesObserver.Data.Jsons
{
    internal class DotaInfo
    {
        public static string FromJsonTakeCharacterImg(int id)
        {
            string path = @"C:\Users\User\source\repos\GamesObserver\GamesObserver\Data\Jsons\Assets\heroes.json";
            string json = File.ReadAllText(path);
            JObject keyValuePairs = JObject.Parse(json);
            IList<JToken> list = keyValuePairs["heroes"].Children().ToList();

            string _imgPath = "";

            foreach (JToken token in list)
            {
                if (id == token["id"].ToObject<int>())
                {
                    _imgPath = token["url_small_portrait"].ToObject<string>();
                }
            }

            return _imgPath;
        }

        public static string FromJsonTakeItemsImg(int id)
        {
            string path = @"C:\Users\User\source\repos\GamesObserver\GamesObserver\Data\Jsons\Assets\items.json";
            string json = File.ReadAllText(path);
            JObject keyValuePairs = JObject.Parse(json);
            IList<JToken> list = keyValuePairs["items"].Children().ToList();

            string _imgPath = "";

            foreach (JToken token in list)
            {
                if (id == token["id"].ToObject<int>())
                {
                    _imgPath = token["url_image"].ToObject<string>();
                }
            }

            return _imgPath;
        }
    }
}
