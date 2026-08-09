using ShelterApi.Data;
using ShelterApi.Models;
using ShelterApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ShelterApi.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly AppDbContext _context;

        public ShelterRepository(AppDbContext context)
        {
            _context = context;
        }

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
    }
}
