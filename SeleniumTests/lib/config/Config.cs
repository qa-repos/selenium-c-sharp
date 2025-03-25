namespace SeleniumTests.lib.config;

public static class Config
{
    public static string BaseUrl =>
        Environment.GetEnvironmentVariable("BASE_URL") ?? "https://demoqa.com";

    public static bool IsCi =>
        Environment.GetEnvironmentVariable("CI")?.ToLower() == "true";
    
    public static string ApiUrl => "https://demoqa.com";
    
}
