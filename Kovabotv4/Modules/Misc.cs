using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Kovabotv4.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("echo")]
        public async Task Echo([Remainder]string message) //remainder is pass the rest of the string as one argument instead of splitting at spaces
        {
            var embed = new EmbedBuilder(); //bots can embed text, users cannot
            embed.WithTitle($"{Context.User.Username} says:");
            embed.WithDescription(message);
            embed.WithColor(new Color(37, 94, 186));

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("choose")]
        public async Task Choose([Remainder]string message)
        {
            string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries); //this is done to split at a specific character

            Random r = new Random();
            string selection = options[r.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle($"@{Context.User.Username}, my choice is: ");
            embed.WithDescription(selection);
            embed.WithColor(new Color(37, 94, 186));
            embed.WithThumbnailUrl("https://i.imgur.com/321AM00.png");

            await Context.Channel.SendMessageAsync("I HAVE SPOKEN!", false, embed.Build());
            
        }
    }
}
