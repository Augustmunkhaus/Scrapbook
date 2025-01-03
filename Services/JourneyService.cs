using ScrapBook.Repositories;

namespace ScrapBook.Services;

public class JourneyService : IJourneyService
{
    private readonly JourneyRepository _journeyRepository;
    private readonly JourneyImageRepository _journeyImageRepository;
    
    public JourneyService(JourneyRepository journeyRepository, JourneyImageRepository journeyImageRepository)
    {
        _journeyRepository = journeyRepository;
        _journeyImageRepository = journeyImageRepository;
    }
    
    public async Task<List<Journey>> GetAllJourneysAsync()
    {
        return await _journeyRepository.GetAllAsync();
    }
    
    public async Task<Journey> GetJourneyByIdAsync(int id)
    {
        return await _journeyRepository.GetByIdAsync(id);
    }
    
    public async Task CreateJourneyAsync(Journey journey)
    {
        // Business logic can go here, e.g., validation
        await _journeyRepository.AddAsync(journey);
    }
    
    public async Task UpdateJourneyAsync(Journey journey)
    {
        // Additional business logic could go here
        await _journeyRepository.UpdateAsync(journey);
    }
    
    public async Task DeleteJourneyAsync(int id)
    {
        await _journeyRepository.DeleteAsync(id);
    }
    
}