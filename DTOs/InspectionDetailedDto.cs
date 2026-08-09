

namespace ShelterApi.DTOs;

public class InspectionDetailedDto
{
    public int inspectionId { get; set; }
    public DateTime inspectionDate { get; set; }
    public double readinessScore { get; set; }
    public bool passed { get; set; }
    public string shelterName { get; set; } = string.Empty;
    public string city { get; set; } = string.Empty;
    public string neighborhood { get; set; } = string.Empty;
}
