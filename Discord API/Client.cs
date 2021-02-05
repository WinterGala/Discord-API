using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace Discord_API
{
    public partial class Client : IDisposable
    {
        private static readonly Uri ApiBase = new Uri(@"https://discordapp.com/api/v6/");

        //private StreamWriter messageLog = new StreamWriter(@"C:\Users\glen_\desktop\messagelog.txt");
        //private StreamWriter serializedLog = new StreamWriter(@"C:\Users\glen_\desktop\serializedlog.txt");

        public delegate void ChannelCreate(Opcode.Channel channel);
        public delegate void ChannelUpdate(Opcode.Channel channel);
        public delegate void ChannelDelete(Opcode.Channel channel);
        public delegate void MessageCreate(Opcode.Message message);
        public delegate void MessageDelete(Opcode.Message message);
        public delegate void Ready(Opcode.Ready ready);
        public delegate void PresenceUpdate(Opcode.PresenceUpdate presence);
        public delegate void TypingStart(Opcode.TypingStart typing);

        public event ChannelCreate OnChannelCreate;
        public event ChannelUpdate OnChannelUpdate;
        public event ChannelDelete OnChannelDelete;
        public event MessageCreate OnMessageCreate;
        public event MessageDelete OnMessageDelete;
        public event Ready OnReady;
        public event PresenceUpdate OnPresenceUpdate;
        public event TypingStart OnTypingStart;

        private System.Timers.Timer _timer;
        private HttpClient _client;
        private WebSocket _webSocket;
        private string _token;
        private string _session_id;
        private int _last_sequence_number;

        private User _me;

        public enum GatewayOpcode : int
        {
            Dispatch = 0,
            Heartbeat = 1,
            Identify = 2,
            StatusUpdate = 3,
            VoiceStateUpdate = 4,
            Resume = 6,
            Reconnect = 7,
            RequestGuildMembers = 8,
            InvalidSession = 9,
            Hello = 10,
            HeartbeatAcknowledge = 11
        }

        public enum GatewayEvent : int
        {
            
        }

        public Client(string email, string password)
        {
            this.ClientSetup();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                {"captcha_key",  null},
                {"email", email},
                {"gift_code_sku_id", null},
                {"login_source", null},
                {"password", password},
                {"undelete", null}
            };

            string json = JsonConvert.SerializeObject(values);

            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp(ApiBase + "auth/login");
            request.ContentType = "application/json";
            request.Method = "POST";
            using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(json);
                sw.Flush();
                sw.Close();
            }

            using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                JObject jObj = JObject.Parse(reader.ReadToEnd());
                if (jObj["mfa"].ToObject<bool>() == true)
                {
                    string ticket = jObj["ticket"].ToString();

                    this.SendSMSCodeRequest(ticket);

                    Console.Write("Enter code: ");
                    string code = Console.ReadLine();
                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("code", code);
                    param.Add("ticket", ticket);
                    string vals = JsonConvert.SerializeObject(param);
                    HttpWebRequest req = (HttpWebRequest)WebRequest.CreateHttp(ApiBase + "auth/mfa/sms");
                    req.ContentType = "application/json";
                    req.Method = "POST";
                    using (StreamWriter sw = new StreamWriter(req.GetRequestStream()))
                    {
                        sw.Write(vals);
                        sw.Flush();
                        sw.Close();
                    }

                    using (StreamReader r = new StreamReader(req.GetResponse().GetResponseStream()))
                    {
                        jObj = JObject.Parse(r.ReadToEnd());
                    }
                }
                _token = jObj["token"].ToString();
            }

            ConnectionProperties connectionProperties = new ConnectionProperties();
            connectionProperties.Os = "Windows 10";
            connectionProperties.Browser = "Firefox";
            connectionProperties.Device = "Laptop";

            this.WebSocketSetup();

            this.HeartBeat();
            this.OpcodeIdentify(connectionProperties);
        }

        public Client(string token)
        {
            this.ClientSetup();
            this._token = token;
            this.WebSocketSetup();
            this.HeartBeat();
            ConnectionProperties connectionProperties = new ConnectionProperties();
            connectionProperties.Os = "Windows 10";
            connectionProperties.Browser = "Firefox";
            connectionProperties.Device = "Laptop";
            this.OpcodeIdentify(connectionProperties);
        }

        private void ClientSetup()
        {
            this._client = new HttpClient(new HttpClientHandler() { CookieContainer = new CookieContainer() });
            this._client.BaseAddress = ApiBase;
        }

        public void WebSocketSetup()
        {
            this._client.DefaultRequestHeaders.Add("Authorization", this._token);
            this._webSocket = new WebSocket("wss://gateway.discord.gg/?v=6&encoding=json");
            this._webSocket.OnClose += (sender, e) =>
            {
                Console.WriteLine(e.Reason);
                Console.WriteLine(e.Code);
                Console.WriteLine(e.WasClean);
            };

            this._webSocket.OnMessage += (sender, e) =>
            {
                Payload payload = JsonConvert.DeserializeObject<Payload>(e.Data);
                this.OpcodeDispatch(payload);
            };

            this._webSocket.OnOpen += (sender, e) =>
            {
                Console.WriteLine(e);
            };
            this._webSocket.Connect();
        }

        public void SendSMSCodeRequest(string ticket)
        {
            HttpWebRequest mfaReq = (HttpWebRequest)WebRequest.CreateHttp(ApiBase + "auth/mfa/sms/send");
            mfaReq.ContentType = "application/json";
            mfaReq.Method = "POST";

            using (StreamWriter w = new StreamWriter(mfaReq.GetRequestStream()))
            {
                Dictionary<string, string> d = new Dictionary<string, string>() { { "ticket", ticket } };
                string j = JsonConvert.SerializeObject(d);
                Console.WriteLine(j);
                w.Write(j);
                w.Flush();
                w.Close();
            }

            mfaReq.GetResponse();
        }

        private void OpcodeIdentify(ConnectionProperties connectionProperties)
        {
            Dictionary<string, object> message = new Dictionary<string, object>()
            {
                {"token", this._token },
                {"properties", connectionProperties}
            };
            Dictionary<string, object> payloadData = new Dictionary<string, object>()
            {
                {"op", 2},
                {"d", message}
            };
            string payload = JsonConvert.SerializeObject(payloadData);
            this._webSocket.Send(payload);
        }

        private void Resume()
        {
            Dictionary<string, object> vals = new Dictionary<string, object>()
            {
                {"token", this._token},
                {"session_id", this._session_id},
                {"seq", this._last_sequence_number}
            };
        }

        private void HeartBeat()
        {
            Dictionary<string, int?> heartBeat = new Dictionary<string, int?>()
            {
                {"op", 1},
                {"d", this._last_sequence_number}
            };

            string message = JsonConvert.SerializeObject(heartBeat);
            this._webSocket.Send(message);
            Console.WriteLine("beat");
        }

        private void OpcodeDispatch(Payload payload)
        {
            switch (payload.Opcode)
            {
                case 0: // Dispatch
                    this._last_sequence_number = (int)payload.SequenceNumber;
                    //this.messageLog.Write(payload.Data.ToString());
                    //this.messageLog.FlushAsync().Wait();
                    switch (payload.EventName)
                    {
                        case "CHANNEL_CREATE":
                            if (this.OnChannelCreate != null)
                            {
                                Opcode.Channel channel = JsonConvert.DeserializeObject<Opcode.Channel>(payload.Data.ToString());
                                this.OnChannelCreate(channel);
                            }
                            break;
                        case "CHANNEL_UPDATE":
                            if (this.OnChannelUpdate != null)
                            {
                                Opcode.Channel channel = JsonConvert.DeserializeObject<Opcode.Channel>(payload.Data.ToString());
                                OnChannelUpdate(channel);
                            }
                            break;
                        case "CHANNEL_DELETE":
                            if (this.OnChannelDelete != null)
                            {
                                Opcode.Channel channel = JsonConvert.DeserializeObject<Opcode.Channel>(payload.Data.ToString());
                                this.OnChannelDelete(channel);
                            }
                            break;
                        case "CHANNEL_PINS_UPDATE":
                            break;
                        case "GUILD_CREATE":
                            break;
                        case "GUILD_UPDATE":
                            break;
                        case "GUILD_DELETE":
                            break;
                        case "GUILD_BAN_ADD":
                            break;
                        case "GUILD_BAN_REMOVE":
                            break;
                        case "GUILD_EMOJIS_UPDATE":
                            break;
                        case "GUILD_INTEGRATIONS_UPDATE":
                            break;
                        case "GUILD_MEMBER_ADD":
                            break;
                        case "GUILD_MEMBER_REMOVE":
                            break;
                        case "GUILD_MEMBER_UPDATE":
                            break;
                        case "GUILD_MEMBERS_CHUNK":
                            break;
                        case "GUILD_ROLE_CREATE":
                            break;
                        case "GUILD_ROLE_UPDATE":
                            break;
                        case "GUILD_ROLE_DELETE":
                            break;
                        case "READY":
                            Opcode.Ready ready = JsonConvert.DeserializeObject<Opcode.Ready>(payload.Data.ToString());
                            this._me = ready.User;
                            this._session_id = ready.SessionId;
                            if (this.OnReady != null)
                            {
                                OnReady(ready);
                            }
                            break;
                        case "PRESENCE_UPDATE":
                            if (this.OnPresenceUpdate != null)
                            {
                                Opcode.PresenceUpdate presence = JsonConvert.DeserializeObject<Opcode.PresenceUpdate>(payload.Data.ToString());
                                OnPresenceUpdate(presence);
                            }
                            break;
                        case "TYPING_START":
                            //Opcode.TypingStart typing = JsonConvert.DeserializeObject<Opcode.TypingStart>(payload.Data.ToString());
                            //OnTypingStart(typing);
                            break;
                        case "MESSAGE_CREATE":
                            if (this.OnMessageCreate != null)
                            {
                                Opcode.Message message = JsonConvert.DeserializeObject<Opcode.Message>(payload.Data.ToString());
                                OnMessageCreate(message);
                            }
                            break;
                        default:
                            Console.WriteLine(payload.EventName);
                            break;
                    }
                    break;
                case 7: // Reconnect
                    break;
                case 9: // Invalid session
                    break;
                case 10: //Hello
                    Opcode.Hello hello = JsonConvert.DeserializeObject<Opcode.Hello>(payload.Data.ToString());
                    this._timer = new System.Timers.Timer(hello.HeartbeatInterval);
                    this._timer.AutoReset = true;
                    this._timer.Elapsed += (source, e) => this.HeartBeat();
                    this._timer.Enabled = true;
                    break;
                case 11: // Heartbeat acknowledge
                    break;
                default:
                    //Console.WriteLine(JsonConvert.SerializeObject(payload));
                    break;
            }
        }

        internal async Task<T> ResponseHandler<T>(HttpResponseMessage response, HttpStatusCode statusCode)
        {
            if (response.StatusCode == statusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }

            throw new Exception();
        }

        public User Me => this._me;
        public String SessionId => this._session_id;
        public string Token => this._token;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (this._webSocket.IsAlive)
                    {
                        this._webSocket.Close();
                    }

                    //this.messageLog.Flush();
                    //this.serializedLog.Flush();
                    //this.messageLog.Dispose();
                    //this.serializedLog.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Client()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
