using Microsoft.AspNetCore.Mvc;
using Todo.API.Models;
using Todo.API.Dtos;

namespace Todo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private static List<TodoItem> todos = new List<TodoItem>();
    public TodoController()
    {
        
    }

    [HttpGet("GetTodoItems")]
    public ActionResult<IEnumerable<TodoItem>> GetAll()
    {
        return todos;
    }

    [HttpGet("GetTodoItem")]
    public ActionResult<TodoItem> GetTodo(int id)
    {
        return todos.FirstOrDefault(todo => todo.Id == id);
    }

    [HttpPost("CreateTodoItem")]
    public ActionResult<TodoItem> CreateTodo(CreateTodoDto createItem)
    {
        var newId = todos.Count > 0 ? todos.OrderBy(x => x.Id).Last().Id + 1 : 1;
        var newTodo = new TodoItem()
        {
            Id = newId,
            Title = createItem.Title,
            Body = createItem.Body,
            Completed = createItem.Completed
        };

        todos.Add(newTodo);

        return newTodo;
    }

    [HttpPut("UpdateTodo")]
    public ActionResult<TodoItem> UpdateTodo(int id, CreateTodoDto updatedItem)
    {
        var todo = todos.FirstOrDefault(item => item.Id == id);
        if(todo == null)
        {
            throw new HttpRequestException($"TodoItem with id: {id} was not found.",
                                           null,
                                           System.Net.HttpStatusCode.NotFound);
        }

        todo.Title = updatedItem.Title;
        todo.Body = updatedItem.Body;
        todo.Completed = updatedItem.Completed;

        return todo;
    }

    [HttpDelete("DeleteTodoItem")]
    public ActionResult<TodoItem> DeleteTodo(int id)
    {
        var todo = todos.FirstOrDefault(item => item.Id == id);
        if(todo == null)
        {
            throw new HttpRequestException($"TodoItem with id: {id} was not found.",
                                           null,
                                           System.Net.HttpStatusCode.NotFound);
        }

        todos.Remove(todo);

        return todo;
    }
}

