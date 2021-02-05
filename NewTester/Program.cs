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
            Client client = new Client("gwolfarth10@gmail.com", "uzCV7zN9epucGGd1TPgr");
            client.OnReady += (ready) =>
            {
                /*Console.WriteLine("Session Id: {0} Token: {1}", ready.SessionId, client.Token);
                Console.WriteLine("Username: {0}", ready.User.Username);*/
                foreach (Discord_API.Opcode.Guild guild in ready.Guilds.OrderByDescending(g => g.Channels.Length))
                {
                    Console.WriteLine("Guild name: {0} - Number of channels: {1}", guild.Name, guild.Channels.Length);
                    foreach (Discord_API.Opcode.Channel channel in guild.Channels)
                    {
                        Console.WriteLine(channel.Name);
                    }
                    Console.WriteLine();
                }

                client.DeleteMessage(546061654429925437, 628646572552355871).Wait();
            };
            /*client.OnPresenceUpdate += (presence) =>
            {
                Console.WriteLine("User {0} is {1}", presence.User.Id.Id, presence.Status.ToString());
            };*/
            client.OnTypingStart += (typing) =>
            {
                Console.WriteLine("User: {0} Guild: {1} Channel: {2} Timestamp: {3}", typing.UserId, typing.GuildId, typing.ChannelId, typing.Timestamp);
            };

            Thread.Sleep(1000 * 5);
            Console.ReadLine();
        }
    }
}
