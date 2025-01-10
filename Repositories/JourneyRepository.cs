using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrapBook.Repositories
{
    public class JourneyRepository : IJourneyRepository
    {
        private readonly AppDbContext _context;

        public JourneyRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Journey>> GetAllAsync()
        {
           return await _context.Journeys.ToListAsync();
        }

        public async Task<Journey> GetByIdAsync(int id)
        {
            return await _context.Journeys.Include(j => j.Images)
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task AddAsync(Journey journey)
        {
            foreach (var image in journey.Images)
            {
                image.Journey = journey; // billeder til spefifik rejse
            }
            _context.Journeys.Add(journey);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Journey journey)
        {
            _context.Journeys.Update(journey);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var journey = await _context.Journeys.FindAsync(id);
            if (journey != null)
            {
                _context.Journeys.Remove(journey);
                await _context.SaveChangesAsync();
            }
        }
    }
}