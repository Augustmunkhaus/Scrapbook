using Microsoft.AspNetCore.Mvc;
using ScrapBook.Repositories;
using System.Threading.Tasks;

//Controller in this project is not necessary, but it's added for good measure and practice.

[ApiController]
[Route("api/[controller]")]
public class JourneysController : ControllerBase
{
    private readonly IJourneyRepository _journeyRepository;

    public JourneysController(IJourneyRepository journeyRepository)
    {
        _journeyRepository = journeyRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var journeys = await _journeyRepository.GetAllAsync();
        return Ok(journeys);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var journey = await _journeyRepository.GetByIdAsync(id);
        if (journey == null) return NotFound();

        return Ok(journey);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Journey journey)
    {
        if (id != journey.Id) return BadRequest("ID not matching");

        await _journeyRepository.UpdateAsync(journey);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJourney(int id)
    {
        var journey = await _journeyRepository.GetByIdAsync(id);
        if (journey == null) return NotFound();

        await _journeyRepository.DeleteAsync(id);
        return NoContent();
    }
}