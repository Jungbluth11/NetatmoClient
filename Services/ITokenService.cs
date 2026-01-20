namespace NetatmoClient.Services;

public interface ITokenService
{
    Task<string> GetAccessTokenAsync();
}