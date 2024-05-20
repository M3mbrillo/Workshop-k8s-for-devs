using System.Text;

namespace MoonlyBird.Poll.Api.Util;

public class PollAdminClient
{
    private readonly HttpClient _httpClient;

    public PollAdminClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<HttpResponseMessage> Vote(Guid pollId, Guid optionId, Guid userId, CancellationToken cancellationToken)
    {
        
        var content = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                PollId =  pollId,
                OptionId = optionId,
                UserId = userId
            }),
            Encoding.UTF8,
            "application/json");

        return await _httpClient.PostAsync("/vote", content, cancellationToken);
    }

    public async Task<HttpResponseMessage> GetPolls(CancellationToken cancellationToken)
    {
        return await _httpClient.GetAsync("/poll", cancellationToken);
    }
}