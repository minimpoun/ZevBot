using Discord.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace ZevBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("ToMemeText")]
        public async Task ToMemeText([Remainder] string Message)
        {
            StringBuilder _NewString = new StringBuilder();
            for (int Index = 0; Index < Message.Length; ++Index)
            {
                if (Index % 2 == 0)
                {
                    _NewString.Append(Message[Index].ToString().ToUpper());
                }
                else
                {
                    _NewString.Append(Message[Index].ToString());
                }
            }

            var _Embed = new EmbedBuilder();
           // _Embed.WithTitle("Here is your Meme Text:");
            _Embed.WithColor(0, 255, 0);
            _Embed.WithDescription(_NewString.ToString());

            await Context.Channel.SendMessageAsync("", false, _Embed);
        }

        [Command("FAQ")]
        public async Task FAQ([Remainder] string Question = "null")
        {
            Dictionary<string, string> _FAQ;
            string _FAQJson = BotUtils.GetJsonFromFile("Json/FAQ.json").ToString();
            var _Data = BotUtils.GetDataFromJson(_FAQJson);
            _FAQ = _Data.ToObject<Dictionary<string, string>>();

            string _Answer = "";

            string _NewQuestion = Question.ToLower();
            string _FirstLetter = Question[0].ToString().ToUpper();

            if (Question.Length > 1 && !Question.Contains(" "))
            {
                _NewQuestion = _FirstLetter + Question.Remove(0, 1);
            }
            else if (Question.Length > 1 && Question.Contains(" "))
            {
                string[] _SubStrings = _NewQuestion.Split(' ');
                string _SubTwo = _SubStrings[1];
                string _SecondLetter = _SubTwo[0].ToString().ToUpper();
                _NewQuestion = _FirstLetter + _SubStrings[0].Remove(0, 1) + " " + _SecondLetter + _SubStrings[1].Remove(0, 1);
            }
          
            if (_FAQ.ContainsKey(_NewQuestion))
            {
                _FAQ.TryGetValue(_NewQuestion, out _Answer);
            }
            else
            {
                _Answer = "List of Valid Questions: \n";
                for (int Index = 0; Index < _FAQ.Count; ++Index)
                {
                    _Answer += _FAQ.Keys.ElementAt(Index) + "\n";
                }
            }

            var _Embed = new EmbedBuilder();
            _Embed.WithTitle("FAQ:");
            _Embed.WithColor(0, 255, 0);
            _Embed.WithDescription(_Answer);
            await Context.Channel.SendMessageAsync("", false, _Embed);
        }

        [Command("Help")]
        public async Task Help(string Message = "null")
        {
            var _Channel = await Context.User.GetOrCreateDMChannelAsync();
            Message = Message.ToLower();

            if (_Channel != Context.Channel)
            {
                await Context.Channel.SendMessageAsync(Context.User.Mention + " Sent you a PM!");
            }

            if (!Message.Contains("all"))
            {
                await _Channel.SendMessageAsync(BotUtils.GetAlert("HELP"));
            }
            else
            {
                await _Channel.SendMessageAsync(BotUtils.GetAlert("COMMANDS"));
            }
        }

        [Command("Twitter")]
        public async Task Twitter()
        {
            var _Embed = new EmbedBuilder();
            _Embed.WithTitle("Follow the Apeiron Twitter for all the latest updates!");
            _Embed.WithUrl("https://twitter.com/apeiron_kotor");
            _Embed.WithImageUrl("https://pbs.twimg.com/media/DXq6ucEX0AA0EUY.jpg");
            await Context.Channel.SendMessageAsync("", false, _Embed);
        }
    }
}
