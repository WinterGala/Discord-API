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
        /// <summary>
        /// Returns the user object of the requester's account. 
        /// For OAuth2, this requires the identify scope, which will return the object without an email, 
        /// and optionally the email scope, which returns the object with an email.
        /// </summary>
        /// <returns>Returns the user object of the requester's account.</returns>
        public async Task<User> GetCurrentUser()
        {
            HttpResponseMessage response = await this._client.GetAsync("users/@me");

            return await this.ResponseHandler<User>(response, HttpStatusCode.OK);
        }

        /// <summary>
        /// Returns a user object for a given user ID.
        /// </summary>
        /// <param name="userId">The snowflake of the user to retrieve.</param>
        /// <returns>Returns the user with the provided snowflake value.</returns>
        public async Task<User> GetUser(Snowflake userId)
        {
            HttpResponseMessage response = await this._client.GetAsync(string.Format("users/{0}", userId.Id));

            return await this.ResponseHandler<User>(response, HttpStatusCode.OK);
        }


        /// <summary>
        /// Modify the requester's user account settings.
        /// </summary>
        /// <param name="username">User's username, if changed may cause the users discriminator to be randomized.</param>
        /// <returns>Returns a user object on success.</returns>
        public async Task<User> ModifyCurrentUser(string username)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modify the requester's user account settings.
        /// </summary>
        /// <param name="username">User's username, if changed may cause the users discriminator to be randomized.</param>
        /// <param name="avatarData">Modifies the user's avatar.</param>
        /// <returns>Returns a user object on success.</returns>
        public async Task<User> ModifyCurrentUser(string username, string avatarData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of partial guild objects the current user is a member of. Requires the guilds OAuth2 scope.
        /// </summary>
        /// <param name="before">Get guilds before this guild ID.</param>
        /// <param name="after">Get guilds after this guild ID.</param>
        /// <param name="limit">Max number of guilds to return (1-100).</param>
        /// <returns>List of guild objects.</returns>
        public async Task<Opcode.Guild[]> GetCurrentUserGuilds(Snowflake before = null, Snowflake after = null, uint limit = 100)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Leave a guild.
        /// </summary>
        /// <param name="guildId">Id of the Guild to leave.</param>
        public async void LeaveGuild(Snowflake guildId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of DM channel objects.
        /// </summary>
        /// <returns>Returns a list channel objects.</returns>
        public async Task<Opcode.Channel[]> GetUserDMs()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new DM channel with a user.
        /// </summary>
        /// <param name="recipientId">The recipient to open a DM channel with.</param>
        /// <returns>Returns a DM channel object.</returns>
        public async Task<Opcode.Channel> CreateDM(Snowflake recipientId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of connection objects. Requires the connections OAuth2 scope.
        /// </summary>
        /// <returns>Returns a list of connection objects.</returns>
        public async Task<Opcode.Connection> GetUserConnections()
        {
            throw new NotImplementedException();
        }
    }
}
