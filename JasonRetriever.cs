using System.Net.Http;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace JsonXunitTestProject;

public class JasonRetriever
{
    private readonly string _urlString;
    

    public JasonRetriever(string urlString)
    {
        _urlString = urlString;
        
    }

    public async Task<string> ReadJsonAsync()
    {
        var client = new HttpClient();

        var response = await client.GetAsync(_urlString);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;

    }
}