using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create
{
    public class MyFirstModule : BaseCommandModule 
    {
        [Command("great")]
        public async Task GreetCommand(CommandContext ctx)
        {
            
            await ctx.RespondAsync("Estou sendo executadoooooooo");
        }
    }
}
