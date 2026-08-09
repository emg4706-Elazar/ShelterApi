

using ShelterApi.Enums;
using ShelterApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ShelterApi.DTOs;

public class ShelterSortedDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string BuildingNumber { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public bool IsAccessible { get; set; }
    public bool IsPublic { get; set; }
    public ShelterTypes ShelterType { get; set; }
}
