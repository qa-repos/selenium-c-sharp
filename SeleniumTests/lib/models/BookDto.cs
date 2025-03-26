namespace SeleniumTests.lib.models;

public class BookDto
{
    public string ISBN { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string SubTitle { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public int Pages { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
}
