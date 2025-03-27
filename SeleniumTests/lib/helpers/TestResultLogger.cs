using System.Collections.Concurrent;

namespace SeleniumTests.lib.helpers;

public static class TestResultLogger
{
    private static readonly ConcurrentBag<(string Name, string Status)> _results = new();

    public static void Log(string testName, bool passed)
    {
        var status = passed ? "\x1b[32m✅ PASSED\x1b[0m" : "\x1b[31m❌ FAILED\x1b[0m";
        _results.Add((testName, status));
    }

    public static void PrintSummary()
    {
        Console.WriteLine("\n📊 Test Summary:");
        Console.WriteLine(new string('-', 50));
        foreach (var (name, status) in _results)
        {
            Console.WriteLine($"{status,-15} | {name}");
        }
        Console.WriteLine(new string('-', 50));
    }
}