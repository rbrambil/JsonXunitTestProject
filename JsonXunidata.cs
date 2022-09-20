using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonXunitTestProject;

public class DexcomData
{
    [JsonProperty("Product Name")] public string? ProductName { get; set; }

    [JsonProperty("UDI / Device Identifier")]
    public string? DeviceIdentifier { get; set; }

    [JsonProperty("UDI / Production Identifier")]
    public ProductionIdentifierData? ProductionIdentifier { get; set; }
}

public class ProductionIdentifierData
{

    [JsonProperty("Version")] 
    public string? Version { get; set; }

    [JsonProperty("Date of Manufacture (DOM)")]
    public string? ManufactureDate { get; set; }

    [JsonProperty("Part Number (PN)")] 
    public string? PartNumber { get; set; }

    [JsonProperty("Sub-Components")] 
    public List<SubComponent>? SubComponents { get; set; }
}

public class SubComponent
{
    [JsonProperty("Name")] public string? Name { get; set; }

    [JsonProperty("gitSHA")] public string? GitSha { get; set; }
}
