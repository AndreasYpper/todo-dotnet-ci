namespace Todo.API.Dtos;

public class CreateTodoDto
{
    public string Title { get; set; }
    public string Body { get; set; }
    public bool Completed { get; set; }
}