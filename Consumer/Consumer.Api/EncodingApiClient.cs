using System.Text;
using System.Text.Json;

namespace Consumer.Api;

public class EncodingApiClient
{
    private readonly HttpClient _client;

    public EncodingApiClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<string> Encode(string input)
    {
        var response = await _client.PostAsync(
            "/",
            new StringContent(
                JsonSerializer.Serialize(
                    new EncodeRequest
                    {
                        Value = input
                    }
                ),
                Encoding.UTF8, 
                "application/json"
            )
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    private class EncodeRequest
    {
        public string Value { get; set; }
    }
}