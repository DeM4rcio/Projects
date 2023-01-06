using System;
using System.Threading.Tasks;
using DSharpPlus;

namespace MyFirstBot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "MTA1NDc3MDE4ODU3NjM1ODQzMA.GRijRs.K0lbR5b1FY-ZQ5lYmoF1w5ILB-2SdIzNTiaUWE",
                TokenType = TokenType.Bot
            });

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");

            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}