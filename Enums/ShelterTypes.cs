using System.Text.Json.Serialization;

namespace ShelterApi.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ShelterTypes
{
    PublicBuilding,
    School,
    Parking,
    Residential,
    Commercial,
}
