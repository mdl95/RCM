using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;


namespace RCM.API.Support.Authentication
{
    public class RcmAuthenticator : AuthenticatorBase
    {
        private readonly string _baseUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public RcmAuthenticator(string baseUrl, string clientId, string clientSecret) : base("")
        {
            _baseUrl = baseUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            var token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
            return new HeaderParameter(KnownHeaders.Authorization, token);
        }

        async Task<string> GetToken()
        {
            var options = new RestClientOptions(_baseUrl);

            using var client = new RestClient(options)
            {
                Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret),
            };

            var request = new RestRequest("oauth2/token")
                .AddParameter("grant_type", Config.GRANT_TYPE)
                .AddParameter("scope", "email")
                .AddParameter("scope", "openid")
                .AddParameter("scope", "profile");
            
            var response = await client.PostAsync<TokenResponse>(request);
            
            return $"{response!.TokenType} {response!.AccessToken}";
        }
    }
}
