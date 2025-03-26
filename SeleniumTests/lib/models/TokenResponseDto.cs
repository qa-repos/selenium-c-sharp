namespace SeleniumTests.lib.models;

public class TokenResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string Expires { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
}