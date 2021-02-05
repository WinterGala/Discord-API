using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_API.Opcode
{
    public struct GuildFolder
    {
        public readonly string Name;
        public readonly uint Id; //I don't know this for certain
        public readonly Snowflake[] GuildIds;
        public readonly uint Color;
    }
}
