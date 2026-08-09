using System.ComponentModel.DataAnnotations;

namespace ShelterApi.Models;

public class Area
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Neighborhood { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    

}
