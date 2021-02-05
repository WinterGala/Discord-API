using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct ActivityParty
    {
        [JsonProperty(PropertyName = "id")]
        private string _id;
        [JsonProperty(PropertyName = "size")]
        private uint[] _size;

        public string Id => this._id;
        public uint CurrentSize => this._size[0];
        public uint MaxSize => this._size[1];
    }
}
