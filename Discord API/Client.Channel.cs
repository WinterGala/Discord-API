using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Discord_API
{
    public partial class Client
    {
        public async Task<Opcode.Channel> GetChannel(ulong channelId)
        {
            HttpResponseMessage response = await this._client.GetAsync(string.Format("channels/{0}", channelId));

            if (response.IsSuccessStatusCode)
            {
                string str = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Opcode.Channel>(str);
            }

            //Create exception handler
            throw new Exception();
        }

        //Incomplete method since the message object isn't finished
        public async Task<Opcode.Message[]> GetChannelMessages(ulong channelId, Snowflake around = null, Snowflake before = null, Snowflake after = null, uint limit = 50)
        {
            if (limit < 1 || limit > 100)
                throw new ArgumentOutOfRangeException();

            string parameters = string.Format("?limit={0}", limit);

            if (around != null && before != null && after != null)
            {
                if (around != null && (before == null && after == null))
                    parameters = string.Format("&around={0}", around);
                else if (before != null && (around == null && after == null))
                    parameters = string.Format("&before={0}", before);
                else if (after != null && (around == null && before == null))
                    parameters = string.Format("&after={0}", after);
                else
                    throw new ArgumentException();
            }

            HttpResponseMessage response = await this._client.GetAsync(string.Format("channels/{0}/messages{1}", channelId, parameters));
            if (response.IsSuccessStatusCode)
            {
                string str = response.Content.ReadAsStringAsync().Result;
                List<Opcode.Message> messages = JsonConvert.DeserializeObject<List<Opcode.Message>>(str);
                return messages.ToArray();
            }

            throw new Exception();
        }

        public async Task<Opcode.Message> CreateMessage(ulong channelId, string content = "", Opcode.Embed embed = null)
        {
            if (content.Length > 2000)
                throw new ArgumentOutOfRangeException();

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, string.Format("channels/{0}/messages", channelId));
            Dictionary<string, object> vals = new Dictionary<string, object>();
            
            if (!string.IsNullOrWhiteSpace(content))
            {
                vals.Add("content", content);
            }

            if (embed != null)
            {
                vals.Add("embed", embed);
            }

            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(vals), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(vals));

            //FormUrlEncodedContent formContent = new FormUrlEncodedContent(kvs);

            //HttpResponseMessage response = await this._client.PostAsync(string.Format("channels/{0}/messages", channelId), formContent);
            HttpResponseMessage response = await this._client.SendAsync(requestMessage);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Opcode.Message>(response.Content.ReadAsStringAsync().Result);
            }

            throw new Exception();
        }

        public async Task<Opcode.Message> CreateMessage(ulong channelId, Opcode.Message message)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMessage(ulong channelId, Opcode.Message message)
        {
            await this.DeleteMessage(channelId, message.Id.Id);
        }

        public async Task DeleteMessage(ulong channelId, ulong messageId)
        {
            HttpResponseMessage response = await this._client.DeleteAsync(string.Format("channels/{0}/messages/{1}", channelId, messageId));
            if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                throw new Exception();
        }

        public async Task<Opcode.Message> EditMessage(ulong channelId, ulong messageId, string content = "")
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("content", content);
            string con = JsonConvert.SerializeObject(dict);
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), string.Format("channels/{0}/messages/{1}", channelId, messageId));
            request.Content = new System.Net.Http.StringContent("{\"content\":\"Boop\"}", Encoding.UTF8, "application/json");

            HttpResponseMessage response = await this._client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Opcode.Message>(response.Content.ReadAsStringAsync().Result);
            }

            throw new Exception();
        }

        public async Task TriggerTypingIndicator(Opcode.Channel channel)
        {
            await this.TriggerTypingIndicator(channel.Id.Id);
        }

        public async Task TriggerTypingIndicator(ulong channelId)
        {
            HttpResponseMessage response = await this._client.PostAsync(string.Format("channels/{0}/typing", channelId), null);

            if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                throw new Exception();
        }

        public async Task<Opcode.Message[]> GetPinnedMessages(Opcode.Channel channel)
        {
            return await this.GetPinnedMessages(channel.Id.Id);
        }

        public async Task<Opcode.Message[]> GetPinnedMessages(ulong channelId)
        {
            HttpResponseMessage response = await this._client.GetAsync(string.Format("channels/{0}/pins", channelId));

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Opcode.Message[] messages = JsonConvert.DeserializeObject<Opcode.Message[]>(json);
                return messages;
            }

            throw new Exception();
        }

        public async Task<Opcode.Channel> DeleteChannel(ulong channelId)
        {
            HttpResponseMessage response = await this._client.DeleteAsync(string.Format("channels/{0}", channelId));

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Opcode.Channel channel = JsonConvert.DeserializeObject<Opcode.Channel>(json);
                return channel;
            }

            throw new Exception();
        }

        public async Task<Opcode.Invite> GetChannelInvites(ulong channelId)
        {
            HttpResponseMessage response = await this._client.GetAsync(string.Format("channels/{0}/invites", channelId));

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
            }

            throw new Exception();
        }
    }
}
