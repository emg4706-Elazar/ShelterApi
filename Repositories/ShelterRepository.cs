using ShelterApi.Data;
using ShelterApi.Models;
using ShelterApi.DTOs;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Enums;
using Microsoft.AspNetCore.Http.Features;

namespace ShelterApi.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly AppDbContext _context;

        public ShelterRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all shelters
        public async Task<IEnumerable<ShelterWithAreaDto>> GetAllSheltersAsync()
        {
            return await _context.Shelters.
                Select(s => new ShelterWithAreaDto
                {
                    shelterId = s.Id,
                    shelterName = s.Name,
                    capacity = s.Capacity,
                    city = s.Area.City,
                    neighborhood = s.Area.Neighborhood
                }).ToListAsync();
        }

        // Search by filters
        public async Task<IEnumerable<ShelterSearchResultDto>> SearchAsync(
            string? city, int? minCapacity, bool isAccessible, bool isPublic)
        {
            var query = _context.Shelters.AsQueryable();
            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(s => s.Area.City.ToLower() == city);
            }

            if (minCapacity.HasValue)
            {
                query = query.Where(s => s.Capacity >= minCapacity);
            }

            if (isAccessible)
            {
                query = query.Where(s => s.IsAccessible);
            }

            if (isPublic)
            {
                query = query.Where(s => s.IsPublic);
            }

            return await query.Select(s => new ShelterSearchResultDto
            {
                id = s.Id,
                name = s.Name,
                street = s.Street,
                capacity = s.Capacity,
                isAccessible = s.IsAccessible,
                city = s.Area.City
            }).ToListAsync();
        }

        // Get sorted shelters list
        public async Task<IEnumerable<ShelterSortedDto>> GetSortedSheltersAsync(
            string? sortBy, bool ascending=true)
        {
            var query = _context.Shelters.AsQueryable();

            query = sortBy?.ToLower() switch
            {
                "capacity" => ascending ? query.OrderBy(s => s.Capacity) :
                query.OrderByDescending(s => s.Capacity),

                "city" => ascending ? query.OrderBy(s => s.Area.City):
                query.OrderByDescending(s => s.Area.City),
                
                _ => ascending ? query.OrderBy(s => s.Name):
                query.OrderByDescending(s => s.Name)
            };

            return await query.Select(s => new ShelterSortedDto
            {
                Id = s.Id,
                Name = s.Name,
                Street = s.Street,
                BuildingNumber = s.BuildingNumber,
                Capacity = s.Capacity,
                IsAccessible = s.IsAccessible,
                IsPublic = s.IsPublic,
                ShelterType = s.ShelterType
            }).ToListAsync();
        }

        // Get all inspections
        public async Task<IEnumerable<InspectionDetailedDto>>
            GetAllInsppectionsAsync()
        {
            return await _context.Inspections
                .Select(i => new InspectionDetailedDto
                {
                    inspectionId = i.Id,
                    inspectionDate = i.InspectionDate,
                    readinessScore = i.ReadinessScore,
                    passed = i.Passed,
                    shelterName = i.Shelter.Name,
                    city = i.Shelter.Area.City,
                    neighborhood = i.Shelter.Area.Neighborhood
                }).ToListAsync();
        }

        // Get all shelters with there inspections count
        public async Task<IEnumerable<ShelterWithInspectionCountDto>>
            GetSheltersWithInspectionsCountAsync()
        {
            return await _context.Shelters
                .Select(s => new ShelterWithInspectionCountDto
                {
                    shelterId = s.Id,
                    shelterName = s.Name,
                    inspectionCount = s.Inspections.Count
                }).ToListAsync();
        }

        // Get only failed inspecitons
        public async Task<IEnumerable<FailedInspectionDto>> GetFailedInspectionsAsync()
        {
            return await _context.Inspections.Where(i => !i.Passed)
                .Select(i => new FailedInspectionDto
                {
                    inspectionId = i.Id,
                    inspectionDate = i.InspectionDate,
                    readinessScore = i.ReadinessScore,
                    defectsCount = i.DefectsCount,
                    shelterName = i.Shelter.Name,
                    city = i.Shelter.Area.City
                }).ToListAsync();
        }

        // Get Statistics for area
        public async Task<IEnumerable<AreaStatisticsDto>> GetAreaStatisticsAsync()
        {
            return await _context.Areas
                .Select(a => new AreaStatisticsDto
                {
                    city = a.City,
                    neighborhood = a.Neighborhood,
                    shelterCount = a.Shelters.Count,
                    totalCapacity = a.Shelters.Sum(s => s.Capacity)
                }).ToListAsync();
        }

        // Get average score by type
        public async Task<IEnumerable<ShelterTypeAverageDto>>
            GetAverageScoreByTypeAsync(ShelterTypes shelterType)
        {
            return await _context.Shelters
                .GroupBy(s => s.ShelterType)
                .Select(s => new ShelterTypeAverageDto
                {
                    shelterType = s.Key,
                    averageReadinessScore = s.
                    SelectMany(s => s.Inspections)
                    .Average(i => i.ReadinessScore),
                    totalInspections = s.Sum(s => s.Inspections.Count)

                }).ToListAsync();
        }

        public async Task<PagedResultDto<ShelterWithAreaDto>>
            GetPagedAsync(int page, int pageSize)
        {
            var total = await _context.Shelters.CountAsync();

            var items = await _context.Shelters
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new ShelterWithAreaDto
                {
                    shelterId = s.Id,
                    shelterName = s.Name,
                    capacity = s.Capacity,
                    city = s.Area.City,
                    neighborhood = s.Area.Neighborhood
                }).ToListAsync();

            return new PagedResultDto<ShelterWithAreaDto>
            {
                Items = items,
                totalCount = total,
                page = page,
                pageSize = pageSize,
                totalPages = pageSize > 0 ? total / pageSize: 0
            };
        }
    }
}
