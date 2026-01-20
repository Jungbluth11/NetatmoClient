using Microsoft.Kiota.Http.HttpClientLibrary;
using NetatmoClient.Addwebhook;
using NetatmoClient.Createnewschedule;
using NetatmoClient.Devicelist;
using NetatmoClient.Dropwebhook;
using NetatmoClient.Getcamerapicture;
using NetatmoClient.Geteventsuntil;
using NetatmoClient.Gethomecoachsdata;
using NetatmoClient.Gethomedata;
using NetatmoClient.Getlasteventof;
using NetatmoClient.Getmeasure;
using NetatmoClient.Getnextevents;
using NetatmoClient.Getpublicdata;
using NetatmoClient.Getstationsdata;
using NetatmoClient.Getthermostatsdata;
using NetatmoClient.Getthermstate;
using NetatmoClient.Getuser;
using NetatmoClient.Partnerdevices;
using NetatmoClient.Services;
using NetatmoClient.Setpersonsaway;
using NetatmoClient.Setpersonshome;
using NetatmoClient.Setthermpoint;
using NetatmoClient.Switchschedule;
using NetatmoClient.Syncschedule;

namespace NetatmoClient;

public partial class NetatmoClient
{
    private readonly NetatmoBaseClient _client;

    public string RefreshToken { get; internal set; } = string.Empty;

    public AddwebhookRequestBuilder Addwebhook => _client.Addwebhook;

    public CreatenewscheduleRequestBuilder Createnewschedule => _client.Createnewschedule;

    public DevicelistRequestBuilder Devicelist => _client.Devicelist;

    public DropwebhookRequestBuilder Dropwebhook => _client.Dropwebhook;

    public GetcamerapictureRequestBuilder Getcamerapicture => _client.Getcamerapicture;

    public GeteventsuntilRequestBuilder Geteventsuntil => _client.Geteventsuntil;

    public GethomecoachsdataRequestBuilder Gethomecoachsdata => _client.Gethomecoachsdata;

    public GethomedataRequestBuilder Gethomedata => _client.Gethomedata;

    public GetlasteventofRequestBuilder Getlasteventof => _client.Getlasteventof;

    public GetmeasureRequestBuilder Getmeasure => _client.Getmeasure;

    public GetnexteventsRequestBuilder Getnextevents => _client.Getnextevents;

    public GetpublicdataRequestBuilder Getpublicdata => _client.Getpublicdata;

    public GetstationsdataRequestBuilder Getstationsdata => _client.Getstationsdata;

    public GetthermostatsdataRequestBuilder Getthermostatsdata => _client.Getthermostatsdata;

    public GetthermstateRequestBuilder Getthermstate => _client.Getthermstate;

    public GetuserRequestBuilder Getuser => _client.Getuser;

    public PartnerdevicesRequestBuilder Partnerdevices => _client.Partnerdevices;

    public SetpersonsawayRequestBuilder Setpersonsaway => _client.Setpersonsaway;

    public SetpersonshomeRequestBuilder Setpersonshome => _client.Setpersonshome;

    public SetthermpointRequestBuilder Setthermpoint => _client.Setthermpoint;

    public SwitchscheduleRequestBuilder Switchschedule => _client.Switchschedule;

    public SyncscheduleRequestBuilder Syncschedule => _client.Syncschedule;

    public NetatmoClient(string clientId, string clientSecret, string refreshToken)
    {
        RefreshToken = refreshToken;
        TokenService tokenService = new(clientId, clientSecret, this);
        NetatmoAuthProvider authProvider = new(tokenService);
        HttpClientRequestAdapter adapter = new(authProvider);

        _client = new(adapter);
    }

    public NetatmoClient(ITokenService tokenService)
    {
        NetatmoAuthProvider authProvider = new(tokenService);
        HttpClientRequestAdapter adapter = new(authProvider);

        _client = new(adapter);
    }
}