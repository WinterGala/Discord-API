using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Discord_API;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Client client = new Client("gwolfarth10@gmail.com", "uzCV7zN9epucGGd1TPgr");
            Client client = new Client("mfa.oSBnM_4ULRBPT9y8ihOA2a2BoO79OSxc93Fe4vMXpqFeG6SQp5pcd8xbr4coTcKZR_7gNICg5QHA14lKSd1g");
            client.OnReady += (ready) =>
            {
                /*foreach (Discord_API.Opcode.Guild guild in ready.Guilds.OrderByDescending(g => g.Channels.Length))
                {
                    Console.WriteLine("Guild name: {0} - Number of channels: {1}", guild.Name, guild.Channels.Length);
                    foreach (Discord_API.Opcode.Channel channel in guild.Channels)
                    {
                        Console.WriteLine(channel.Name);
                    }
                    Console.WriteLine(client.Token);
                }*/

                Console.WriteLine(client.Token);
                //Discord_API.Opcode.Channel[] c = client.GetGuildChannels(650445434128433162).Result;

                /*foreach (Discord_API.Opcode.Channel channel in c)
                {
                    Console.WriteLine(channel.Name);
                    Console.WriteLine(channel.Topic);
                }*/

                //Discord_API.Opcode.Guild guild = client.GetGuild(650445434128433162).Result;

                /*foreach (Discord_API.Opcode.GuildMember member in guild.GuildMembers)
                {
                    Console.WriteLine(member.Nickname);
                }*/
                //User u = client.GetUser(195094859961335808).Result;
                //Discord_API.Opcode.Guild g = client.GetGuild(221830355928350723).Result;
                Discord_API.Opcode.Embed tweet = new Discord_API.Opcode.Embed();
                //tweet.Footer.Text = "Twitter • 11 / 09 / 2016";
                tweet.Color = 0x1DA1F2;
                Discord_API.Opcode.EmbedAuthor author = new Discord_API.Opcode.EmbedAuthor();
                author.IconUrl = "https://pbs.twimg.com/profile_images/461964160838803457/8z9FImcv_400x400.png";
                author.Name = "The Associated Press (@AP)";
                author.Url = "https://media.tenor.com/images/333cf6c5b1aed66544e8b873cb2e4e2b/tenor.gif";
                tweet.Author = author;
                Discord_API.Opcode.EmbedField f1 = new Discord_API.Opcode.EmbedField();
                f1.Name = "**Retweets**";
                f1.Value = "11591";
                f1.Inline = true;
                Discord_API.Opcode.EmbedField f2 = new Discord_API.Opcode.EmbedField();
                f2.Name = "**Likes**";
                f2.Value = "10826";
                f2.Inline = true;
                Discord_API.Opcode.EmbedFooter footer = new Discord_API.Opcode.EmbedFooter();
                footer.Text = "Twitter";
                footer.IconUrl = "https://d.ibtimes.co.uk/en/full/1487456/twitter-logo.png";
                tweet.Timestamp = DateTime.Now;
                tweet.Footer = footer;
                tweet.Fields = new[] { f1, f2 };
                tweet.Description = "BREAKING: Nevada voting results wrapping up, Trump leads the state.";
                tweet.Url = "https://twitter.com/AP/status/796253849497571328";
                //_ = client.CreateMessage(322082027249598475, "bruh <https://twitter.com/AP/status/796253849497571327>", embed: tweet).Result;

                Discord_API.Opcode.Guild g = client.GetGuild(168244873424535553).Result;
                foreach (Discord_API.Opcode.Channel c in client.GetGuildChannels(168244873424535553).Result)
                {
                    Console.WriteLine(c.Name);
                    Console.WriteLine(c.Topic);
                    Console.WriteLine("-------------------------------------------------------------------");
                }

                Console.WriteLine();

                //client.CreateGuildChannel(542847013583061022, "Test", Discord_API.Opcode.Channel.ChannelType.GuildStore, parentId: 618941915781529671).Wait();
            };
            
            client.OnTypingStart += (typing) =>
            {
                Console.WriteLine("User: {0} Guild: {1} Channel: {2} Timestamp: {3}", typing.UserId, typing.GuildId, typing.ChannelId, typing.Timestamp);
            };

            client.OnMessageCreate += (message) =>
            {
                if (message.Content.StartsWith("c!avatar"))
                {
                    User u;

                    if (message.Mentions.Length == 0)
                        u = message.Author;
                    else
                        u = message.Mentions[0];

                    client.CreateMessage(message.ChannelId, string.Format("https://cdn.discordapp.com/avatars/{0}/{1}.png", u.Id.Id, u.Avatar)).Wait();
                }
                else if (message.Mentions.Contains(client.Me) && message.Author.Id.Id != client.Me.Id.Id && message.Author.Id.Id != 81216833633386496)
                {
                    client.CreateMessage(message.ChannelId, string.Format("<@{0}>", message.Author.Id.Id)).Wait();
                }
            };

            Thread.Sleep(1000 * 5);
            Console.ReadLine();
        }   

        private static void Client_OnMessageCreate(Discord_API.Opcode.Message message)
        {
            
        }
    }
}
