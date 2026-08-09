

namespace ShelterApi.DTOs;

public class ShelterWithInspectionCountDto
{
    public int shelterId { get;set; }
    public string shelterName { get; set; } = string.Empty;
    public int inspectionCount { get; set; }
}
