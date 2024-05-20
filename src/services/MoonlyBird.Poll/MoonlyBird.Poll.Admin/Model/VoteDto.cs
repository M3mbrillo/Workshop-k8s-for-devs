namespace MoonlyBird.Poll.Admin.Model;

public record VoteDto(Guid PollId, Guid OptionId, Guid UserId);