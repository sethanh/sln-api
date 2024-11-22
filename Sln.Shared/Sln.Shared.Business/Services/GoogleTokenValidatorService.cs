using Google.Apis.Auth;

namespace Sln.Shared.Business.Services
{
    public class GoogleTokenValidatorService(string clientId)
    {
        private readonly string _clientId = clientId;

        public async Task<GoogleJsonWebSignature.Payload?> ValidateTokenAsync(string idToken)
        {
            try
            {
                // Validate the ID token
                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { _clientId } // Validate against your Client ID
                });

                return payload;
            }
            catch (InvalidJwtException ex)
            {
                Console.WriteLine($"Invalid token: {ex.Message}");
                return null;
            }
        }
    }
}