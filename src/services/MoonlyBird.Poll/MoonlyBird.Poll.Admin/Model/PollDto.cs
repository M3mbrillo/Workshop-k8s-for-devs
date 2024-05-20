namespace MoonlyBird.Poll.Admin.Model;

public record PollDto(
    Guid? Id,
    string Name, 
    OptionDto[] options
    );