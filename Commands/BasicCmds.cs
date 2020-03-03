using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;



namespace OnePieceDiscoBot.Commands
{
    public class Info : ModuleBase
    {
        [Command("say"), Summary("Echos a message.")]
        public async Task Say([Remainder, Summary("The text to echo")] string echo)
        {
            await ReplyAsync(echo);
        }
    }

    [Group("random")]
    public class Random : ModuleBase
    {
        [Command("roll"), Summary("rolls a dice")]
        public async Task roll()
        {
            Console.WriteLine("rolled");

            System.Random rand = new System.Random();
            int result = (rand.Next() % 6) + 1;

            await ReplyAsync(String.Format("You rolled a {0}", result));
        }
    }

    
   
}
