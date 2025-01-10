using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrapBook.Repositories
{
    public class JourneyImageRepository : IJourneyImageRepository
    {
        private readonly AppDbContext _context;

        public JourneyImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JourneyImage>> GetImagesByJourneyIdAsync(int journeyId)
        {
            return await _context.JourneyImages
                .Where(img => img.JourneyId == journeyId)
                .ToListAsync();
        }

        public async Task AddAsync(JourneyImage image)
        
        {
            _context.JourneyImages.Add(image);
            await _context.SaveChangesAsync();
        }
    }
}