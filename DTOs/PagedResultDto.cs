using ShelterApi.Models;

namespace ShelterApi.DTOs;

public class PagedResultDto<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int totalCount { get; set; }
    public int page { get; set; }
    public int pageSize { get; set; }
    public int totalPages { get; set; }

}
