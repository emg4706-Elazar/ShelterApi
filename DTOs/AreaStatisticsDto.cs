

namespace ShelterApi.DTOs;

public class AreaStatisticsDto
{
    public string city { get; set; } = string.Empty;
    public string neighborhood { get; set; } = string.Empty;
    public int shelterCount { get; set; }
    public int totalCapacity { get; set; }
}
