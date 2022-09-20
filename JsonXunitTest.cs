using System.Collections.Generic;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace JsonXunitTestProject;

public class JsonXunitTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string url =
        "https://api.dexcom.com/info";
        //"https://sandbox-api.dexcom.com/info";

    public JsonXunitTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }


    [Fact]
    public void TestFirstProductName()
    {
        var jsonData = JsonUtilities.GetStringFromJson(url);

        //_testOutputHelper.WriteLine(jsonData);

        Assert.NotNull(jsonData);

        var productList = JsonConvert.DeserializeObject<List<DexcomData>> (jsonData);
        //_testOutputHelper.WriteLine(productList.ToString());

        Assert.NotNull(productList);
        Assert.NotNull(productList[0]);
        Assert.Equal("Dexcom API", productList[0].ProductName);

        _testOutputHelper.WriteLine(productList[0].ProductName);
    }

    [Fact]
    public void TestFirstDeviceIdentifier()
    {
        var jsonData = JsonUtilities.GetStringFromJson(url);
        Assert.NotNull(jsonData);
        var productList = JsonConvert.DeserializeObject<List<DexcomData>>(jsonData);
        Assert.Equal(productList[0].DeviceIdentifier, "00386270000668");
        _testOutputHelper.WriteLine(productList[0].DeviceIdentifier);
    }

    [Fact]
    public void TestFirstProductionIdentifier()
    {
        var jsonData = JsonUtilities.GetStringFromJson(url);
        Assert.NotNull(jsonData);
        var productList = JsonConvert.DeserializeObject<List<DexcomData>>(jsonData);

        Assert.Equal(productList[0].ProductionIdentifier.Version, "3.1.1.0");
        Assert.Equal(productList[0].ProductionIdentifier.ManufactureDate, "2022-07-27");
        Assert.Equal(productList[0].ProductionIdentifier.PartNumber, "350-0019");
        Assert.Equal(productList[0].ProductionIdentifier.SubComponents[0].Name, "api-gateway");
        Assert.Equal(productList[0].ProductionIdentifier.SubComponents[0].GitSha,
            "614c5317ff0f6c8a5ff192a5bfbe438e804c068b");
        Assert.Equal(productList[0].ProductionIdentifier.SubComponents[1].Name, "standard-offering");
        Assert.Equal(productList[0].ProductionIdentifier.SubComponents[1].GitSha,
            "eada49ad06b48465a31af2afba7f68d492bf022d");

        _testOutputHelper.WriteLine(productList[0].ProductionIdentifier.Version);
        _testOutputHelper.WriteLine(productList[0].ProductionIdentifier.ManufactureDate);
        _testOutputHelper.WriteLine(productList[0].ProductionIdentifier.PartNumber);
        _testOutputHelper.WriteLine(productList[0].ProductionIdentifier.SubComponents[0].Name);
        _testOutputHelper.WriteLine(productList[0].ProductionIdentifier.SubComponents[0].GitSha);
        _testOutputHelper.WriteLine(productList[0].ProductionIdentifier.SubComponents[1].Name);
        _testOutputHelper.WriteLine(productList[0].ProductionIdentifier.SubComponents[1].GitSha);

        
    }

    [Fact]
    public void TestSecondProductName()
    {
        var jsonData = JsonUtilities.GetStringFromJson(url);
        Assert.NotNull(jsonData);
        var productList = JsonConvert.DeserializeObject<List<DexcomData>>(jsonData);

        Assert.Equal(productList[1].ProductName, "Dexcom Partner Web API realtime");

        _testOutputHelper.WriteLine(productList[1].ProductName);
    }

    [Fact]
    public void TestSecondDeviceIdentifier()
    {
        var jsonData = JsonUtilities.GetStringFromJson(url);
        Assert.NotNull(jsonData);
        var productList = JsonConvert.DeserializeObject<List<DexcomData>>(jsonData);

        Assert.Equal(productList[1].DeviceIdentifier, "00386270000392");

        _testOutputHelper.WriteLine(productList[1].DeviceIdentifier);

    }

    [Fact]
    public void TestSecondProductionIdentifier()
    {
        var jsonData = JsonUtilities.GetStringFromJson(url);
        Assert.NotNull(jsonData);
        var productList = JsonConvert.DeserializeObject<List<DexcomData>>(jsonData);

        Assert.Equal(productList[1].ProductionIdentifier.Version, "3.0.6.0");
        Assert.Equal(productList[1].ProductionIdentifier.ManufactureDate, "2022-03-02");
        Assert.Equal(productList[1].ProductionIdentifier.PartNumber, "SW12025");
        Assert.Equal(productList[1].ProductionIdentifier.SubComponents[0].Name, "realtime-offering");
        Assert.Equal(productList[1].ProductionIdentifier.SubComponents[0].GitSha,
            "614c5317ff0f6c8a5ff192a5bfbe438e804c068b");

        _testOutputHelper.WriteLine(productList[1].ProductionIdentifier.Version);
        _testOutputHelper.WriteLine(productList[1].ProductionIdentifier.ManufactureDate);
        _testOutputHelper.WriteLine(productList[1].ProductionIdentifier.PartNumber);
        _testOutputHelper.WriteLine(productList[1].ProductionIdentifier.SubComponents[0].GitSha);
        _testOutputHelper.WriteLine(productList[1].ProductionIdentifier.SubComponents[0].Name);
        



    }
}