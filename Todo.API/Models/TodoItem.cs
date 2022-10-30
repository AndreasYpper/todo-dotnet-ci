namespace Todo.API.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public bool Completed { get; set; }
}

