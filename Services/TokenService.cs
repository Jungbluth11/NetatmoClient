using Flurl.Http;
using Newtonsoft.Json.Linq;

namespace NetatmoClient.Services;

public class TokenService(string clientId, string clientSecret, NetatmoClient client) : ITokenService
{
    private string? _accessToken;
    private DateTime _expiresAt = DateTime.MinValue;

    public async Task<string> GetAccessTokenAsync()
    {
        if (!string.IsNullOrEmpty(_accessToken) && DateTime.UtcNow < _expiresAt)
        {
            return _accessToken;
        }

        string tokenUrl = "https://api.netatmo.com/oauth2/token";
        string? response = await tokenUrl
            .PostUrlEncodedAsync(new
            {
                grant_type = "refresh_token",
                client_id = clientId,
                client_secret = clientSecret,
                refresh_token = client.RefreshToken
            })
            .ReceiveString();

        JObject json = JObject.Parse(response);
        _accessToken = json["access_token"]!.Value<string>();
        client.RefreshToken = json["refresh_token"]!.Value<string>()!;
        int expiresIn = json["expires_in"]!.Value<int>();
        _expiresAt = DateTime.UtcNow.AddSeconds(expiresIn);

        return _accessToken!;
    }
}
