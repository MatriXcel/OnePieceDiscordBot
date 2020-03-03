using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace OnePieceDiscoBot
{


    class CommandHandler
    {
        private CommandService _service;
        private DiscordSocketClient _client;

        public CommandHandler(DiscordSocketClient _client)
        {
            this._client = _client;
            _service = new CommandService();

            _client.MessageReceived += handleCommands;

            _service.AddModulesAsync(Assembly.GetEntryAssembly());

        }

        public async Task handleCommands(SocketMessage _messageParam)
        {

            var message = _messageParam as SocketUserMessage;
            if (message == null) return;


            int argPos = 0;

            if (!(message.HasCharPrefix('!', ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))) return;


            var context = new CommandContext(_client, message);
            var result = await _service.ExecuteAsync(context, argPos);

            //if (!result.IsSuccess) await context.Channel.SendMessageAsync(result.ErrorReason);
        }
    }
}
