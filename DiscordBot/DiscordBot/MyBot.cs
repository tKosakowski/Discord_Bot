using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using System.IO;
using Discord.Audio;

namespace DiscordBot
{
    class MyBot
    {
        DiscordClient discord;

        public MyBot()
        {

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hi I am a bot");
                });

            commands.CreateCommand("info")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("I am written in C#");
                });

            commands.CreateCommand("anime")
               .Do(async (e) =>
               {
                   await e.Channel.SendMessage("FUCK ANIME");
               });

            /*commands.CreateCommand("sound")
               .Do((e) =>
               {
                   Console.WriteLine("Some Audio");
                   SendAudio(AppDomain.CurrentDomain.BaseDirectory + "\\test.mp3");
               });
               */

            //var voiceChannel = discord.FindServers("4Head Kappa EleGiggle").FirstOrDefault().VoiceChannels.FirstOrDefault();

            //IAudioClient.Join(Channel);


            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjgyNjE2NDMyODY3NjcyMDc0.C4t_5Q.mRorqG7vzxAITKEsAMQV7lSn1Fw", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
