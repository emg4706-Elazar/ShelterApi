

using ShelterApi.DTOs;
using ShelterApi.Models;

namespace ShelterApi.Repositories;

public interface IShelterRepository
{
    Task<IEnumerable<ShelterWithAreaDto>> GetAllSheltersAsync();
    Task<IEnumerable<ShelterSearchResultDto>> SearchAsync(
        string? city, int? minCapacity, bool isAccessible, bool isPublic);
    Task<IEnumerable<ShelterSortedDto>> GetSortedSheltersAsync(
        string? sortBy, bool ascending = true);
    Task<IEnumerable<InspectionDetailedDto>> GetAllInsppectionsAsync();
    Task<IEnumerable<ShelterWithInspectionCountDto>>
        GetSheltersWithInspectionsCountAsync();
    //Task<IEnumerable<Inspection>> GetFailedInspectionsAsync();
}
