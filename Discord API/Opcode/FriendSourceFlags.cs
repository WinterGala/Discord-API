﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct FriendSourceFlags
    {
        [JsonProperty(PropertyName = "all")]
        public readonly bool All;
    }
}
