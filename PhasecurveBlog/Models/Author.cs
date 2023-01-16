namespace PhasecurveBlog.Models;

public class Author
{
    public Author(int id, string name, DateTime registeredTime, DateTime updatedOn)
    {
        Id = id;
        Name = name;
        RegisteredTime = registeredTime;
        UpdatedOn = updatedOn;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime RegisteredTime { get; set; }
    public DateTime UpdatedOn { get; set; }
}