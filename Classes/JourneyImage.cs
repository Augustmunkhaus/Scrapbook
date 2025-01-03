
public class JourneyImage
{
    public int Id { get; set; }
    public int JourneyId { get; set; } // Foreign key to link with Journey
    public string ImagePath { get; set; } // Path to the image file or URL
    public Journey Journey { get; set; } // Navigation property
}