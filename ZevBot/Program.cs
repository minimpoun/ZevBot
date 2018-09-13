using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using Discord;

namespace ZevBot
{
    class Program
    {
        DiscordSocketClient _Client;
        CommandManger _Manager;

        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            if (!(BotConfigs._BotInstance.sToken == "" || BotConfigs._BotInstance.sToken == null))
            {
                _Client = new DiscordSocketClient(new DiscordSocketConfig
                {
                    LogLevel = LogSeverity.Verbose
                });

                _Client.Log += Log;
                _Manager = new CommandManger();
                await _Client.LoginAsync(TokenType.Bot, BotConfigs._BotInstance.sToken);
                await _Client.StartAsync();

                await _Manager.InitAsync(_Client);
                await Task.Delay(-1);
            }
        }

        private async Task Log(LogMessage Message)
        {
            Console.WriteLine(Message.Message);
        }
    }
}
