using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API
{
    public partial class Client
    {
        public async Task<Opcode.Guild> CreateGuild()
        {
            throw new NotImplementedException();
        }

        public async Task<Opcode.Guild> GetGuild(Opcode.Guild guild)
        {
            return await this.GetGuild(guild.Id);
        }

        public async Task<Opcode.Guild> GetGuild(ulong guildId)
        {
            HttpResponseMessage response = await this._client.GetAsync(string.Format("guilds/{0}", guildId));

            return await this.ResponseHandler<Opcode.Guild>(response, HttpStatusCode.OK);
        }

        public async Task<Opcode.Guild> ModifyGuild()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteGuild(Opcode.Guild guild)
        {
            await this.DeleteGuild(guild.Id);
        }

        public async Task DeleteGuild(ulong guildId)
        {
            HttpResponseMessage response = await this._client.DeleteAsync(string.Format("guilds/{0}", guildId));

            if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                throw new Exception();
        }

        public async Task<Opcode.Channel[]> GetGuildChannels(Opcode.Guild guild)
        {
            return await this.GetGuildChannels(guild.Id);
        }

        public async Task<Opcode.Channel[]> GetGuildChannels(ulong guildId)
        {
            HttpResponseMessage response = await this._client.GetAsync(string.Format("guilds/{0}/channels", guildId));

            return await this.ResponseHandler<Opcode.Channel[]>(response, HttpStatusCode.OK);
        }

        public async Task<Opcode.Channel> CreateGuildChannel(Opcode.Guild guild, string channelName,
                                                             Opcode.Channel.ChannelType? channelType = Opcode.Channel.ChannelType.GuildText, 
                                                             string topic = null, uint? bitrate = null, uint? userlimit = null,
                                                             uint? rateLimitPerUser = null, uint? position = null,
                                                             Opcode.Overwrite[] overwrites = null, Snowflake parentId = null, bool? nsfw = null)
        {
            return await this.CreateGuildChannel(guild.Id, channelName, channelType, topic, bitrate, userlimit, rateLimitPerUser, position, overwrites, parentId, nsfw);
        }

        public async Task<Opcode.Channel> CreateGuildChannel(ulong guildId, string channelName,
                                                             Opcode.Channel.ChannelType? channelType = null,
                                                             string topic = null, uint? bitrate = null, uint? userlimit = null,
                                                             uint? rateLimitPerUser = null, uint? position = null,
                                                             Opcode.Overwrite[] overwrites = null, Snowflake parentId = null, bool? nsfw = null)
        {
            if (channelName.Length < 2 || channelName.Length > 100)
                throw new ArgumentOutOfRangeException();

            Dictionary<string, object> jsonParams = new Dictionary<string, object>();
            jsonParams.Add("name", channelName);

            if (channelType != null)
            {
                jsonParams.Add("type", (uint)channelType);

                if (channelType == Opcode.Channel.ChannelType.GuildVoice)
                {
                    if (bitrate != null)
                        jsonParams.Add("bitrate", bitrate);
                    if (userlimit != null)
                        jsonParams.Add("user_limit", userlimit);
                }
            }

            if (topic != null)
                jsonParams.Add("topic", topic);
            if (rateLimitPerUser != null)
                jsonParams.Add("rate_limit_per_user", rateLimitPerUser);
            if (position != null)
                jsonParams.Add("position", position);
            if (overwrites != null)
                jsonParams.Add("permission_overwrites", overwrites);
            if (parentId != null)
                jsonParams.Add("parent_id", parentId.Id.ToString());
            if (nsfw != null)
                jsonParams.Add("nsfw", nsfw.ToString());

            StringContent parameters = new StringContent(JsonConvert.SerializeObject(jsonParams), Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await this._client.PostAsync(string.Format("guilds/{0}/channels", guildId), parameters);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Opcode.Channel channel = JsonConvert.DeserializeObject<Opcode.Channel>(json);
                return channel;
            }

            throw new NotImplementedException();
        }

        public async Task<Opcode.GuildMember> GetGuildMember(Opcode.Guild guild, Snowflake snowflake)
        {
            return await this.GetGuildMember(guild.Id, snowflake);
        }

        public async Task<Opcode.GuildMember> GetGuildMember(ulong guildId, ulong userId)
        {
            HttpResponseMessage response = await this._client.GetAsync(string.Format("guilds/{0}/members/{1}", guildId, userId));

            return await this.ResponseHandler<Opcode.GuildMember>(response, HttpStatusCode.OK);
        }

        public async Task<Opcode.Role[]> GetGuildRoles(Opcode.Guild guild)
        {
            return await this.GetGuildRoles(guild.Id);
        }

        public async Task<Opcode.Role[]> GetGuildRoles(ulong guildId)
        {
            HttpResponseMessage response = await this._client.GetAsync(string.Format("guilds/{0}/roles", guildId));

            return await this.ResponseHandler<Opcode.Role[]>(response, HttpStatusCode.OK);
        }

        public async Task<Opcode.Ban[]> GetGuildBans(Opcode.Guild guild)
        {
            return await this.GetGuildBans(guild.Id);
        }

        public async Task<Opcode.Ban[]> GetGuildBans(ulong guildId)
        {
            HttpResponseMessage response = await this._client.GetAsync(string.Format("guilds/{0}/bans", guildId));

            return await this.ResponseHandler<Opcode.Ban[]>(response, HttpStatusCode.OK);
        }

        public async Task RemoveGuildBan(Opcode.Guild guild, User user)
        {
            await this.RemoveGuildBan(guild.Id, user.Id);
        }

        public async Task RemoveGuildBan(ulong guildId, ulong userId)
        {
            HttpResponseMessage response = await this._client.DeleteAsync(string.Format("guilds/{0}/bans/{1}", guildId, userId));

            if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                throw new Exception();
        }

        public async Task<Opcode.GuildMember[]> ListGuildMembers(ulong guildId, ushort limit = 1)
        {
            HttpResponseMessage response = await this._client.GetAsync(string.Format("guilds/{0}/members?limit={1}", guildId, limit));

            return await this.ResponseHandler<Opcode.GuildMember[]>(response, HttpStatusCode.OK);
        }
    }
}
