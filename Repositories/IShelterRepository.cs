

using ShelterApi.DTOs;
using ShelterApi.Models;

namespace ShelterApi.Repositories;

public interface IShelterRepository
{
    Task<IEnumerable<ShelterWithAreaDto>> GetAllSheltersAsync();
    Task<IEnumerable<ShelterSearchResultDto>> SearchAsync(
        string? city, int? minCapacity, bool isAccessible, bool isPublic);
    //Task<IEnumerable<Shelter>> GetSortedSheltersAsync(
    //    string sortBy = "name", bool ascending=true);
    //Task<IEnumerable<Inspection>> GetAllInsppectionsAsync();
    //Task<IEnumerable<Shelter>> GetShelterWithInspectionsCountAsync();
    //Task<IEnumerable<Inspection>> GetFailedInspectionsAsync();
}
