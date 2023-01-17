namespace PhasecurveBlog.Models;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Images { get; set; }
    public string Description { get; set; }
    public DateTime Published { get; set; }
    public DateTime LastEdited { get; set; }
}