namespace Infrastructure.Authentication.Jwt
{
    using System.Text.Json.Serialization;

    public class JwtTokenConfig
    {
        [JsonPropertyName("Secret")]
        public string? Secret { get; set; }

        [JsonPropertyName("Issuer")]
        public string? Issuer { get; set; }

        [JsonPropertyName("Audience")]
        public string? Audience { get; set; }

        [JsonPropertyName("AccessTokenExpiration")]
        public string? AccessTokenExpiration { get; set; }

        [JsonPropertyName("RefreshTokenExpiration")]
        public string? RefreshTokenExpiration { get; set; }
    }
}
