using ShelterApi.Enums;

namespace ShelterApi.DTOs;

public class ShelterTypeAverageDto
{
    public ShelterTypes shelterType { get; set; }
    public double averageReadinessScore { get; set; }
    public int totalInspections { get; set; }
}
