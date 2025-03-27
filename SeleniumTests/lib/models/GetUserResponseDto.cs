namespace SeleniumTests.lib.models;

public class GetUserResponseDto
{
    public string UserId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public List<BookDto> Books { get; set; } = new();
}
