namespace SeleniumTests.lib.models;

public class CreateUserResponseDto
{
    public string UserID { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public List<BookDto> Books { get; set; } = new();
}