using Microsoft.AspNetCore.Mvc;
using ShelterApi.DTOs;
using ShelterApi.Repositories;

namespace ShelterApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ShelterController : ControllerBase
{
    private readonly IShelterRepository _repo;
    public ShelterController(IShelterRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShelterWithAreaDto>>> GetAllShelters()
    {
        return Ok(await _repo.GetAllSheltersAsync());
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ShelterSearchResultDto>>> Search(
        string? city, int? minCapacity, bool isAccessible, bool isPublic)
    {
        return Ok(await _repo.SearchAsync(city, minCapacity, isAccessible, isPublic));
    }
}
