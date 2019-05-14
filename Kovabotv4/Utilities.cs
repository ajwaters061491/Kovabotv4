using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; //to read files
using Newtonsoft.Json; //to read JSON

namespace Kovabotv4
{
    class Utilities
    {
        private static Dictionary<string, string> BotInfo;

        static Utilities()
        {
            string json = File.ReadAllText("SystemLang/BotInfo.json");

            var data = JsonConvert.DeserializeObject<dynamic>(json); //These lines convert JSON 
            BotInfo = data.ToObject<Dictionary<string, string>>();   //to normal object data

        }

        public static string GetBotInfo(string key) //returns value of the key if it exists
        {
            if (BotInfo.ContainsKey(key))
            {
                return BotInfo[key];
            }
            else
            {
                return ""; 
            }
        }
    }
}
