using Xunit.Abstractions;

namespace JsonXunitTestProject;

public static class JsonUtilities
{
    //private static object _testOutputHelper;

    public static string GetStringFromJson(string urlString)
    {
        var jsonRetriever = new JasonRetriever(urlString);
        var task = jsonRetriever.ReadJsonAsync();
        return task.Result;
    }
}