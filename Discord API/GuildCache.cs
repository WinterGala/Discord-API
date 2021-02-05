using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_API
{
    internal class GuildCache
    {

        public List<Opcode.Role> Roles = new List<Opcode.Role>();
        public List<Opcode.Channel> Channels = new List<Opcode.Channel>();
    }
}
