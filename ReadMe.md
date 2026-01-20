# NetatmoClient

An easy to use http client for Netatmo.

## Simple Usage

Example:

	var clientId = "your-client-id";
	var clientSecret = "your-client-secret";
	var refreshToken = "your-refresh-token";

	var client = new NetatmoClient(clientId, clientSecret, refreshToken);

	NAStationDataResponse? stations = await client.Getstationsdata.GetAsync();
	foreach (NAMain device in stations.Body.Devices)
	{
		Console.WriteLine($"Station: {device.StationName}");
		Console.WriteLine($"Temperature: {device.DashboardData?.Temperature}°C");
		Console.WriteLine($"CO2: {device.DashboardData?.CO2} ppm");
	}

## Remarks

<b>Your refresh token should be stored persistent.</b> You can access it via `NetatmoClient.RefreshToken` or manage tokens on your own.<br>
To do so create a class that implements `ITokenService` an pass it to the constructor.

Example:

	var clientId = "your-client-id";
	var clientSecret = "your-client-secret";
	var refreshToken = "your-refresh-token";
	
	var tokenService =  new YourTokenSerive(clientId, clientSecret, refreshToken);
	var client = new NetatmoClient(tokenService);

	...

Please also consider https://dev.netatmo.com/apidocumentation/general for full Netatmo API.