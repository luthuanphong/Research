namespace Application.Authentication
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Identity.Web;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public static class AuthenticationExtension
    {
        public static void ConfigureAuthentication(this WebApplicationBuilder builder)
        {
            var authenticationConfig = builder.Configuration.GetSection("Authentication").Get<AuthenticationConfig>();
            // Add singleton in order to use it again
            builder.Services.AddSingleton<AuthenticationConfig>(authenticationConfig);

            // Initialize default JWT authentication
            var authenticationBuilder = builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = true;
                config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authenticationConfig.JwtConfiguration?.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(s: authenticationConfig.JwtConfiguration.Secret)),
                    ValidAudience = authenticationConfig.JwtConfiguration?.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            if (authenticationConfig.UsingGoogle)
            {
                //To do
            }

            if (authenticationConfig.UsingFacebook)
            {
                //To do
            }

            if (authenticationConfig.UsingAzureAD)
            {
                authenticationBuilder.AddMicrosoftIdentityWebApi(builder.Configuration,
                    "AzureAd", ApplicationConstaints.DefaultAzureAuthenticationScheme);
            }

            builder.Services.AddAuthorization(option =>
            {
                option.AddPolicy(ApplicationConstaints.DefaultAuthorizationPolicy, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);

                    if (authenticationConfig.UsingGoogle)
                    {
                        policy.AddAuthenticationSchemes(ApplicationConstaints.DefaultGoogleAuthenticationScheme);
                    }

                    if (authenticationConfig.UsingFacebook)
                    {
                        policy.AddAuthenticationSchemes(ApplicationConstaints.DefaultFacebookAuthenticationScheme);
                    }

                    if (authenticationConfig.UsingAzureAD)
                    {
                        policy.AddAuthenticationSchemes(ApplicationConstaints.DefaultAzureAuthenticationScheme);
                    }

                    policy.RequireAuthenticatedUser();
                });
            });
        }
    }
}
