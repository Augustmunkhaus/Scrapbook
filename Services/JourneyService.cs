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
    
    public async Task AddJourneyAsync(Journey journey)
    {
        foreach (var image in journey.Images)
        {
            image.Journey = journey; // Link images to the journey
        }
        //debug
        Console.WriteLine($"Saving Journey: Title={journey.Title}, Text={journey.Text}");
        
        await _journeyRepository.AddAsync(journey);

        foreach (var image in journey.Images)
        {
            await _journeyImageRepository.AddAsync(image);
        }
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