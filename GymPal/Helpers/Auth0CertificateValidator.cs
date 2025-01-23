using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace GymPal.Helpers
{
    public class Auth0CertificateValidator
    {
        private readonly HttpClient _httpClient;
        private readonly string _auth0Domain;

        public Auth0CertificateValidator(string auth0Domain)
        {
            _httpClient = new HttpClient();
            _auth0Domain = auth0Domain;
        }

        public async Task<X509Certificate2> GetCertificateAsync()
        {
            var jwksJson = await _httpClient.GetStringAsync($"https://{_auth0Domain}/.well-known/jwks.json");
            var jwks = JsonWebKeySet.Create(jwksJson);

            // Get the first signing key (you might want to match the key ID with your token)
            var signingKey = jwks.Keys.First();

            // Convert the signing key to a certificate
            var certificate = new X509Certificate2(Convert.FromBase64String(signingKey.X5c.First()));

            return certificate;
        }
    }
}
