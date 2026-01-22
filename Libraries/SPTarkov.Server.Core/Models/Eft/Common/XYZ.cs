using System.Text.Json.Serialization;

namespace SPTarkov.Server.Core.Models.Eft.Common;

public struct XYZ
{
    [JsonPropertyName("x")]
    public float X { get; set; }

    [JsonPropertyName("y")]
    public float Y { get; set; }

    [JsonPropertyName("z")]
    public float Z { get; set; }
}
