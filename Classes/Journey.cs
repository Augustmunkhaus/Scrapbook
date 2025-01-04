
public class Journey
{
    public int Id {get; set;}
    public string Title { get; set; } = String.Empty;
    public string Text { get; set; } = String.Empty;
    public DateTime Date { get; set; } = DateTime.Today;
    
    public List<JourneyImage> Images { get; set; } = new List<JourneyImage>();
}