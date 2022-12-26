using System;
using System.Reflection;
using System.Threading.Tasks;
using Create;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;

namespace MyFirstBot
{
    class Program
    {
        private DiscordClient _client;
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        

        public async Task MainAsync()
        {
            DiscordConfiguration discord = new DiscordConfiguration()
            {
                Token = "MTA1NDc3MDE4ODU3NjM1ODQzMA.GBjku0.Hvt3USTZqxn1gLeBxgE664NAhwJh8mNvuM63S0",
                TokenType = TokenType.Bot,
                ReconnectIndefinitely = true,
                GatewayCompressionLevel = GatewayCompressionLevel.None,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };

            _client = new DiscordClient(discord);
            _client.Ready += Client_Ready;
            _client.ClientErrored += Client_ClientError;

            string[] prefix = new string[1];
            prefix[0] = "!";

            CommandsNextExtension cnt = _client.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = prefix,
                EnableDms = false,
                CaseSensitive = true,
            });

            cnt.CommandExecuted += Cnt_CommandExecute;

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task Client_Ready (ReadyEventArgs e)
        {
            e.Client.DebugerLogger.LogMessage(LogLevel.Info, "HI!!", "Cliente pronto para processar eventos.", DateTime.Now);
            _

        }
    }
}