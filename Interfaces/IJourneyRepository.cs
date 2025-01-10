

namespace ScrapBook.Repositories
{
    public interface IJourneyRepository
    {
        Task<List<Journey>> GetAllAsync();
        Task<Journey> GetByIdAsync(int id);
        Task AddAsync(Journey journey);
        Task UpdateAsync(Journey journey);
        Task DeleteAsync(int id);
    }
}