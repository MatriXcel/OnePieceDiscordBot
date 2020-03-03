using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using Discord;
using Discord.Net.Providers.WS4Net;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;


namespace OnePieceDiscoBot
{
    class MyBot
    {
        private DiscordSocketClient _client;


        public MyBot()
        {
            DiscordSocketConfig conf = new DiscordSocketConfig();

            conf.WebSocketProvider = WS4NetProvider.Instance;
            conf.MessageCacheSize = 100;
           
            _client = new DiscordSocketClient(conf);

        }

        public async Task Start()
        {

            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, "MzM3NDY5NDgzODI2NTQ0NjQy.DFKJmA.c_2iHWy1JHYK7H-THJSfTSPuF4Q");
            await  _client.StartAsync();


            new CommandHandler(_client);
            

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

      
    }
}

   

