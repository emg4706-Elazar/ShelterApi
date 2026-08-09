using Microsoft.AspNetCore.Mvc;
using ShelterApi.DTOs;
using ShelterApi.Models;
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

    [HttpGet("sorted")]
    public async Task<ActionResult<IEnumerable<Shelter>>> GetSortedShelters(
        string? sortBy, bool ascending)
    {
        return Ok(await _repo.GetSortedSheltersAsync(sortBy, ascending));
    }

    [HttpGet("detailed")]
    public async Task<ActionResult<IEnumerable<InspectionDetailedDto>>> GetAllInsppections()
    {
        return Ok(await _repo.GetAllInsppectionsAsync());
    }

    [HttpGet("with-inspection-count")]
    public async Task<ActionResult<IEnumerable
        <ShelterWithInspectionCountDto>>> GetShelterWithInspectionsCount()
    {
        return Ok(await _repo.GetSheltersWithInspectionsCountAsync());
    }

    [HttpGet("failed")]
    public async Task<ActionResult<IEnumerable<FailedInspectionDto>>>
        GetFailedInspections()
    {
        return Ok(await _repo.GetFailedInspectionsAsync());
    }
}
