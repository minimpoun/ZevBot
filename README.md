# ZevBot -- Custom Bot written in C# for the Apeiron Discord Community
This is a pretty simple bot that uses JSON to handle any text heavy operations.

To use this bot, simply open the Solution, build then navigate to ZevBot/Bin/[YourBuildConfig]/Config.json Open up the Config.json file, inside you should see two options:

* Token
* CommandPrefix  
The token is your Bot token you get from `https://discordapp.com/developers/applications/`

The CommandPrefix is what your users will have to type in order for the bot to recognize it. The bot will responed to the prefix, or being pinged.

***The bot is provided as is***, I did not change any of the source code from the version that is running in the Apeiron discord.
You will have to change and add commands to fit your own needs.

# Prerequisites
* Discord.Net 1.0.2
* Newtonsoft.Json 11.0.2  
Both of these packages can be downloaded with the NuGet Package Manager inside of Visual Studios.
