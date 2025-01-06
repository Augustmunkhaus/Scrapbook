using Microsoft.EntityFrameworkCore;

namespace ScrapBook.Repositories;

public class JourneyImageRepository(AppDbContext context)
{
    
    public async Task<List<JourneyImage>> GetImagesByJourneyIdAsync(int journeyId)
    {
        return await context.JourneyImages
            .Where(img => img.JourneyId == journeyId)
            .ToListAsync();
    }
    public async Task AddAsync(JourneyImage image)
    {
        context.JourneyImages.Add(image); // Add the image to the DbSet
        await context.SaveChangesAsync(); // Save changes to the database
    }
}