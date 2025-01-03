using Microsoft.EntityFrameworkCore;

namespace ScrapBook.Repositories;

public class JourneyRepository
{
    private readonly AppDbContext _context;

    public JourneyRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Journey>> GetAllAsync()
    {
        return await _context.Journeys.Include(j => j.Images).ToListAsync();
    }
    
    public async Task<Journey> GetByIdAsync(int id)
    {
        return await _context.Journeys.Include(j => j.Images)
            .FirstOrDefaultAsync(j => j.Id == id);
    }
 
    public async Task AddAsync(Journey journey)
    {
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