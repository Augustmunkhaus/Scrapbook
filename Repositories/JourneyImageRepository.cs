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
    public async Task AddAsync(JourneyImage image)
    {
        _context.JourneyImages.Add(image); // Add the image to the DbSet
        await _context.SaveChangesAsync(); // Save changes to the database
    }
}