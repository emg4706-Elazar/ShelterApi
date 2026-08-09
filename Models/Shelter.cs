using System.ComponentModel.DataAnnotations;
using ShelterApi.Enums;

namespace ShelterApi.Models;

public class Shelter
{
    public int Id { get; set; }

    [Required]
    public int AreaId { get; set; }

    public Area Area { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string BuildingNumber { get; set; } = string.Empty;

    [Range(1, 10000)]
    public int Capacity { get; set; }

    [Required]
    public bool IsAccessible { get; set; }

    [Required]
    public bool IsPublic { get; set; }

    [Required]
    public ShelterTypes ShelterType { get; set; }
    public ICollection<Inspection> Inspections { get; set; } = null!;
}
