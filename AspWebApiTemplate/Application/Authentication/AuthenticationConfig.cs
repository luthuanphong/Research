namespace Application.Authentication
{
    using Infrastructure.Authentication.Jwt;
    using System.Text.Json.Serialization;

    public class AuthenticationConfig
    {
        [JsonPropertyName("usingAzureAD")]
        public bool UsingAzureAD { get; set; }

        [JsonPropertyName("usingGoogle")]
        public bool UsingGoogle { get; set; }

        [JsonPropertyName("usingFacebook")]
        public bool UsingFacebook { get; set; }

        [JsonPropertyName("jwtConfiguration")]
        public JwtTokenConfig? JwtConfiguration { get; set; }
    }
}
