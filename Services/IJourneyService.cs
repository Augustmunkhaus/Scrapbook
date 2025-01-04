namespace ScrapBook.Services;

public interface IJourneyService
{
    Task<List<Journey>> GetAllJourneysAsync();
    Task<Journey> GetJourneyByIdAsync(int id);
    Task AddJourneyAsync(Journey journey);
    Task UpdateJourneyAsync(Journey journey);
    Task DeleteJourneyAsync(int id);
}