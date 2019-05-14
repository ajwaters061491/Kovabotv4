using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Discord.WebSocket;
using Discord.Commands;

namespace Kovabotv4
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();

            await _service.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),services: null); //awaits incoming discord command services
            _client.MessageReceived += HandleCommandAsync; 
        }

        private async Task HandleCommandAsync(SocketMessage s) //reads the incoming command and handles it
        {
            var msg = s as SocketUserMessage;

            if (msg == null) //this is to prevent the bot from acting on empty messages (broken or buged messages)
            {
                return;
            }

            var context = new SocketCommandContext(_client, msg);
            int argPos = 0; //used to determine where the command prefix starts

            //if using the prefix (!) or mentioning the bot (@kovabotv4)
            if (msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            { 
                var result = await _service.ExecuteAsync(context,argPos, services: null);
                if(!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason); //for debugging
                }
            }
            
        }
    }
}
