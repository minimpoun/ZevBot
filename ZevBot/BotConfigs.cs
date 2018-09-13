using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ZevBot
{
    class BotConfigs
    {
        private const string _ConfigFile = "Json/Config.json";

        public static BotConnectionInfo _BotInstance;

        static BotConfigs()
        {
            if (File.Exists(_ConfigFile))
            {
                string _Json = BotUtils.GetJsonFromFile(_ConfigFile);
                _BotInstance = JsonConvert.DeserializeObject<BotConnectionInfo>(_Json);
                
            }
            else
            {
                _BotInstance = new BotConnectionInfo();
                string _Json = JsonConvert.SerializeObject(_BotInstance, Formatting.Indented);
                File.WriteAllText(_ConfigFile, _Json);
            }
        }
    }

    public struct BotConnectionInfo
    {
        public string sToken;
        public string sCommandPrefix;
    }
}
