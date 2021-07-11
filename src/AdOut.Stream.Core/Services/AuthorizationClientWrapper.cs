using AdOut.Extensions.Authorization;
using AdOut.Stream.Model.Config;
using AdOut.Stream.Model.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdOut.Stream.Core.Services
{
    public class AuthorizationClientWrapper<TClient> : IAuthorizationClientWrapper<TClient>
    {
        private readonly TClient _client;
        private readonly IAuthenticationService _authenticationService;
        private readonly AuthorizationConfig _config;

        public AuthorizationClientWrapper(
            TClient client,
            IAuthenticationService authenticationService,
            IOptions<AuthorizationConfig> config)
        {
            _client = client;
            _authenticationService = authenticationService;
            _config = config.Value;
        }

        //todo: Keep the access token and use it (when the token is expired, request new one)
        
        public async Task<TClient> GetClientAsync()
        {
            var configuration = _client.GetType().GetProperty("Configuration");
            if (configuration != null)
            {
                var configurationObject = configuration.GetValue(_client);
                var defaultHeaders = configuration.PropertyType.GetProperty("DefaultHeader");

                if (defaultHeaders != null)
                {
                    var authResponse = await _authenticationService.AuthenticateAsync(_config.ClientId, _config.ClientSecret);
                    var defaultHeadersObject = (IDictionary<string, string>)defaultHeaders.GetValue(configurationObject);
                    defaultHeadersObject["Authorization"] = $"Bearer {authResponse.AccessToken}";
                }
            }
            return _client;
        }
    }
}
        