using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace ZevBot
{
    class BotUtils
    {
        private static Dictionary<string, string> Alert; 

        static BotUtils()
        {
            string _Json = GetJsonFromFile("Json/Alerts.json");
            var _Data = GetDataFromJson(_Json);
            Alert = _Data.ToObject<Dictionary<string, string>>();
        }

        public static string GetAlert(string Key) => Alert.ContainsKey(Key) ? Alert[Key] : "Invalid Key";
        public static string GetJsonFromFile(string JsonFilePath) => File.ReadAllText(JsonFilePath);
        public static dynamic GetDataFromJson(string JsonFile) => JsonConvert.DeserializeObject<dynamic>(JsonFile);
        public static string GetValueFromIndex(int Index, Dictionary<string, string> In) => In.ElementAt(Index).Value;
    }
}
