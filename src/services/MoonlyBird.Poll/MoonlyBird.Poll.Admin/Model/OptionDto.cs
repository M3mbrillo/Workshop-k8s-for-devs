namespace MoonlyBird.Poll.Admin.Model;

public record OptionDto(
    Guid? Id, string Name, int? Votes
    );