using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrapBook.Repositories
{
    public interface IJourneyImageRepository
    {
        Task<List<JourneyImage>> GetImagesByJourneyIdAsync(int journeyId);
        Task AddAsync(JourneyImage image);
    }
}