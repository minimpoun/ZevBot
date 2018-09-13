using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using System.Reflection;

namespace ZevBot
{
    class CommandManger
    {
        DiscordSocketClient _Client;
        CommandService _CommandService;

        public async Task InitAsync(DiscordSocketClient Client)
        {
            _Client = Client;
            _CommandService = new CommandService();
            await _CommandService.AddModulesAsync(Assembly.GetEntryAssembly());
            _Client.MessageReceived += HandleAsync;
        }

        private async Task HandleAsync(SocketMessage Argc)
        {
            var _Message = Argc as SocketUserMessage;
            if (_Message == null) return;

            var _Context = new SocketCommandContext(_Client, _Message);
            int _Pos = 0;
            if (_Message.HasStringPrefix(BotConfigs._BotInstance.sCommandPrefix, ref _Pos) || _Message.HasMentionPrefix(_Client.CurrentUser, ref _Pos))
            {
                var _Result = await _CommandService.ExecuteAsync(_Context, _Pos);
                if (!_Result.IsSuccess && _Result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(_Result.ErrorReason);
                }
            }
        }
    }
}
