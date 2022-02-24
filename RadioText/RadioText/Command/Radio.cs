using CommandSystem;
using Exiled.API.Features;
using MEC;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RadioText
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Radio : ICommand
    {
        public string Command { get; } = "radio";
        public string[] Aliases { get; } = null;
        public string Description { get; } = null;
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(sender);
            var match = Regex.Match(string.Join(" ", arguments), "(?<=\").*(?=\")");
            foreach (Player player in Player.List.Where(plr => plr.HasItem(ItemType.Radio)))
                if (ply.HasItem(ItemType.Radio))
                {
                    Timing.WaitForSeconds(0.3f);
                    if (arguments.Count == 0)
                    {
                        response = ".radio \"watch out. SCP 173 is doing something with 096.\".";
                        return false;
                    }
                    if (!match.Success)
                    {
                        response = "Use quotes to close the message";
                        return false;
                    }
                    else if (match.Value.Length > 100)
                    {
                        response = "The message is too long.";
                        return false;
                    }
                    else if (string.IsNullOrWhiteSpace(match.Value))
                    {
                        response = "Your message cannot be empty";
                        return false;
                    }
                    else
                    {
                        player.ShowHint($"<color=yellow> Radio: </color> {match.Value}.<color=red> Message of {ply.Nickname}. </color>", 5);
                        response = "Message sended!";
                        return false;
                    }
                }
            response = "You need a radio to use this command.";
            return false;
        }
    }
}
