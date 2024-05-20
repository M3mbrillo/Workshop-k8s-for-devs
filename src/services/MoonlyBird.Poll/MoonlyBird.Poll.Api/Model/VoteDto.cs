namespace MoonlyBird.Poll.Api.Model;

public record VoteDto(Guid PollId, Guid OptionId);