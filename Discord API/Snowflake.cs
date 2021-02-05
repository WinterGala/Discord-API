using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Discord_API
{
    public class Snowflake
    {
        [JsonConstructorAttribute]
        public Snowflake(ulong id)
        {
            this.Id = id;
            this.Increment = (ushort)(id & 0x0FFF);
            this.InternalProcessId = (byte)((id & 0x1F000) >> 12);
            this.InternalWorkerId = (byte)((id & 0x3E0000) >> 17);
            this.Timestamp = new DateTime((long)((id >> 22) + 1420070400000));
        }

        public override bool Equals(object obj)
        {
            Snowflake snowflake = obj as Snowflake;

            if (snowflake == null)
            {
                return false;
            }

            return snowflake.Id == this.Id;
        }

        public static explicit operator Snowflake(string snowflake) => new Snowflake(ulong.Parse(snowflake));
        public static implicit operator ulong(Snowflake s) => s.Id;
        public static implicit operator Snowflake(ulong id) => new Snowflake(id);

        public readonly DateTime Timestamp;
        public readonly byte InternalWorkerId;
        public readonly byte InternalProcessId;
        public readonly ushort Increment;
        public readonly ulong Id;
    }
}
