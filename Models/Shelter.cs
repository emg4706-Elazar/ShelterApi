using System.ComponentModel.DataAnnotations;

namespace ShelterApi.Models;

public class Shelter
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string BuildingNumber { get; set; } = string.Empty;
}
