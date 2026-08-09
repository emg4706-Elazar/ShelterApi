

using Microsoft.Extensions.Primitives;

namespace ShelterApi.DTOs;

public class FailedInspectionDto
{
    public int inspectionId { get; set; }
    public DateTime inspectionDate { get; set; }
    public double readinessScore { get; set; }
    public int defectsCount { get; set; }
    public string shelterName { get; set; } = string.Empty;
    public string city { get; set; } = string.Empty;
}
