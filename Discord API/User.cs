using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API
{
    public struct User
    {
        [Flags]
        public enum UserFlags : uint
        {   
            None = 0,
            DiscordEmployee = 1,
            DiscordPartner = 1 << 1,
            HypeSquadEvents = 1 << 2,
            BugHunter = 1 << 3,
            HouseBrave = 1 << 6,
            HouseBrilliance = 1 << 7,
            HouseBalance = 1 << 8,
            EarlySupporter = 1 << 9,
            TeamUser = 1 << 10
        }

        public enum PremiumType : uint
        {
            NitroClassic = 0,
            Nitro = 1
        }

        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;
        [JsonProperty(PropertyName = "username")]
        public readonly string Username;
        [JsonProperty(PropertyName = "discriminator")]
        public readonly string Discriminator;
        [JsonProperty(PropertyName = "avatar")]
        public readonly string Avatar;
        [JsonProperty(PropertyName = "bot")]
        public readonly bool? IsBot;
        [JsonProperty(PropertyName = "mfa_enabled")]
        public readonly bool? MultiFactorAuthenticationEnable;
        [JsonProperty(PropertyName = "locale")]
        public readonly string Locale;
        [JsonProperty(PropertyName = "verified")]
        public readonly bool? Verified;
        [JsonProperty(PropertyName = "email")]
        public readonly string Email;
        [JsonProperty(PropertyName = "flags")]
        public readonly UserFlags? Flags;
        [JsonProperty(PropertyName = "premium_type")]
        public readonly PremiumType? Premium;
        [JsonProperty(PropertyName = "member")]
        public readonly Opcode.PartialGuildMember? Member;

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            User u = (User)obj;

            return u.Id.Equals(this.Id);
        }
    }
}
