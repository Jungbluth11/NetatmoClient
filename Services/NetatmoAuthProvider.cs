using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace NetatmoClient.Services;

public class NetatmoAuthProvider(ITokenService tokenService) : IAuthenticationProvider
{
    public async Task AuthenticateRequestAsync(RequestInformation request, Dictionary<string, object>? additionalContext = null, CancellationToken cancellationToken = default)
    {
        string token = await tokenService.GetAccessTokenAsync();
        request.Headers.Add("Authorization", $"Bearer {token}");
    }
}
