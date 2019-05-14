using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Kovabotv4
{
    class Config
    {
        private const string configFolder = "Resources"; //folder path
        private const string configFile = "config.json"; //file with bot info

        public static BotConfig bot;

        static Config()
        {
            if (!Directory.Exists(configFolder))
            {
                Directory.CreateDirectory(configFolder);
            }

            if (!File.Exists($"{configFolder}/{configFile}")) //configFolder + "/" + configFile
            {
                bot = new BotConfig(); //if the bot doesn't exist, create a new instance
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented); //formatting set to indented since the json file is naturally indented
                File.WriteAllText($"{configFolder}/{configFile}", json); //write the bot data into a new file
            }
            else
            {
                string json = File.ReadAllText($"{configFolder}/{configFile}");
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
                
            }
        }
    }

    public struct BotConfig
    {
        public string token;
        public string cmdPrefix;
    }

        
    
}
