// See https://aka.ms/new-console-template for more information
using IdentityModel.Client;


var client = new HttpClient();

var disco = await client.GetDiscoveryDocumentAsync("https://localhost:7235");
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
    return;
}

// Request token
var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = disco.TokenEndpoint,
    ClientId = "client",
    ClientSecret = "secret",
    Scope = "api1"
});

if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    return;
}

Console.WriteLine($"Access Token: {tokenResponse.AccessToken}");