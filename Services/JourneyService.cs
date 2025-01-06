using ScrapBook.Repositories;

namespace ScrapBook.Services;

public class JourneyService(JourneyRepository journeyRepository, JourneyImageRepository journeyImageRepository) : IJourneyService
{
    
    public async Task<List<Journey>> GetAllJourneysAsync()
    {
        return await journeyRepository.GetAllAsync();
    }
    
    public async Task<Journey> GetJourneyByIdAsync(int id)
    {
        return await journeyRepository.GetByIdAsync(id);
    }
    
    public async Task AddJourneyAsync(Journey journey)
    {
        foreach (var image in journey.Images)
        {
            image.Journey = journey; // Link images to the journey
        }
        //debug
        Console.WriteLine($"Saving Journey: Title={journey.Title}, Text={journey.Text}");
        
        await journeyRepository.AddAsync(journey);

        foreach (var image in journey.Images)
        {
            await journeyImageRepository.AddAsync(image);
        }
    }
    
    public async Task UpdateJourneyAsync(Journey journey)
    {
        // Additional business logic could go here
        await journeyRepository.UpdateAsync(journey);
    }
    
    public async Task DeleteJourneyAsync(int id)
    {
        await journeyRepository.DeleteAsync(id);
    }
    
}