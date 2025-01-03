using Microsoft.EntityFrameworkCore;

namespace ScrapBook.Repositories;

public class JourneyImageRepository
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
}