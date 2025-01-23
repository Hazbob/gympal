using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using JWT;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using GymPal.config;
using Microsoft.Extensions.Options;

namespace GymPal.Helpers
{
    public class JwtHelper
    {
        private readonly Auth0Secrets _auth0Settings;

        public JwtHelper(IOptions<Auth0Secrets> auth0Secrets)
        {
            _auth0Settings = auth0Secrets.Value;
        }
        public async Task<string> ParseUserFromJWT(string jwt)
        { 
            var validatorToken = new Auth0CertificateValidator(_auth0Settings.Domain);
            var certificate = await validatorToken.GetCertificateAsync();

            var token = jwt.Split(" ")[1];
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtAlgorithm algorithm = new RS256Algorithm(certificate);
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

            var json = decoder.Decode(token);
            var claims = JsonSerializer.Deserialize<Dictionary<string, Object>>(json);
            return claims["sub"].ToString();
            
        }
    }
}
