using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.WebSocket;

namespace Kovabotv4
{
    class Program //system lang folder may be removable later
    {
        DiscordSocketClient _client;
        CommandHandler _handler;

        //discord operates asynchronously
        //forces the main method to immediately run the StartAsync function
        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult(); 

        public async Task StartAsync()
        {
            if(Config.bot.token == "" || Config.bot.token == null) //prevents connection if the token is null or if it is empty
            {
                return;
            }
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            _client.Log += Log;
            
            await _client.LoginAsync(TokenType.Bot, Config.bot.token); //login using the token type (bot) and the token found in the json file
            await _client.StartAsync();
            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
            
        }
    }
}
