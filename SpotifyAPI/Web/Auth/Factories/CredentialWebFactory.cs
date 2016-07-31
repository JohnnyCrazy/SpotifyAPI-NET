using System;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web.Auth.Factories
{
    public class CredentialWebFactory
    {
        private readonly string _secretId;
        private readonly string _clientId;
        private readonly Scope _scope;

        public CredentialWebFactory(string secretId, string clientId, Scope scope)
        {
            _secretId = secretId;
            _clientId = clientId;
            _scope = scope;
        }

        public async Task<SpotifyWebAPI> GetWebApi()
        {
            var authentication = new ClientCredentialsAuth()
            {
                ClientId = _clientId,
                Scope = _scope,
                ClientSecret = _secretId
            };

            AutoResetEvent authenticationWaitFlag = new AutoResetEvent(false);
            SpotifyWebAPI spotifyWebApi = null;

            Token token = await authentication.DoAuthAsync();
            
            if(token.Error != null)
                throw new SpotifyWebApiException(token.Error);

            return Task.FromResult(spotifyWebApi);
        }
    }
}