using NUnit.Framework.Interfaces;
using SeleniumTests.lib.helpers;

namespace SeleniumTests.lib.Base;

public abstract class BaseTestWithLogging
{
    [TearDown]
    public void TrackTestResult()
    {
        var testName = TestContext.CurrentContext.Test.Name;
        var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
        TestResultLogger.Log(testName, passed);
    }

    [OneTimeTearDown]
    public void FinalSummary()
    {
        TestResultLogger.PrintSummary();
    }
}