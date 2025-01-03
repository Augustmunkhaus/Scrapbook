
public class Journey
{
    public int Id {get; set;}
    public string Title {get; set;}
    public string Text { get; set; }
    public DateTime Date { get; set; }
    
    public List<JourneyImage> Images { get; set; } = new List<JourneyImage>();
}