using System.Text.Json;

namespace SeleniumTests.lib.helpers;

public static class JsonHelper
{
    public static T Deserialize<T>(string json) =>
        JsonSerializer.Deserialize<T>(json)!;

    public static string Serialize<T>(T obj) =>
        JsonSerializer.Serialize(obj);
}
