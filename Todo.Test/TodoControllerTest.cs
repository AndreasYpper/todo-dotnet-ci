
namespace Todo.Test;

public class UnitTest1
{
    [Fact]
    public void Given_NoTodoItems_When_GetAll_Then_ReturnEmptyList()
    {
        // Assign
        var sut = new TodoController();

        // Act
        var result = sut.GetAll();

        // Assert
        Assert.Equal(new List<TodoItem>(), result.Value);
    }

    [Fact]
    public void Given_ValidTodoItem_When_CreateTodo_Then_ReturnNewTodo()
    {
        // Assign
        var todo = new CreateTodoDto()
        {
            Title = "test",
            Body = "test",
            Completed = false
        };
        var sut = new TodoController();

        // Act
        var result = sut.CreateTodo(todo);

        // Assert
        Assert.Equal<string>("test", result.Value!.Title);
        Assert.Equal<string>("test", result.Value!.Body);
        Assert.False(result.Value!.Completed);

        sut.DeleteTodo(1);
    }

    [Fact]
    public void Given_TodoItem_When_GetAll_Then_ReturnTodoItem()
    {
        // Given
        var todo = new CreateTodoDto()
        {
            Title = "test",
            Body = "test",
            Completed = false
        };
        
        var sut = new TodoController();
        sut.CreateTodo(todo);

        // When
        var result = sut.GetAll();

        // Then
        Assert.Equal<string>("test", result.Value!.First().Title);
        Assert.Equal<string>("test", result.Value!.First().Body);
        Assert.Equal<bool>(false, result.Value!.First().Completed);
        Assert.Single(result.Value);

        sut.DeleteTodo(1);
    }

    [Fact]
    public void Given_TodoItemExists_When_GetTodo_Then_ReturnTodoItem()
    {
        // Given
        var todo = new CreateTodoDto()
        {
            Title = "test",
            Body = "test",
            Completed = false
        };

        var sut = new TodoController();
        sut.CreateTodo(todo);

        var id = 1;

        // When
        var result = sut.GetTodo(id);

        // Then
        Assert.Equal<string>("test", result.Value!.Title);
        Assert.Equal<string>("test", result.Value!.Body);
        Assert.Equal<bool>(false, result.Value!.Completed);

        sut.DeleteTodo(1);
    }

    [Fact]
    public void Given_UpdatedTodo_When_UpdateTodo_Then_ReturnUpdatedTodoItem()
    {
        // Given
        var todo = new CreateTodoDto()
        {
            Title = "test",
            Body = "test",
            Completed = false
        };

        var updatedTodo = new CreateTodoDto()
        {
            Title = "update",
            Body = "update",
            Completed = true
        };
        var id = 1;
        var sut = new TodoController();
        var createdTodo = sut.CreateTodo(todo);

        // When
        var result = sut.UpdateTodo(id, updatedTodo);

        // Then
        Assert.Equal<string>("update", result.Value!.Title);
        Assert.Equal<string>("update", result.Value!.Body);
        Assert.Equal<bool>(true, result.Value!.Completed);

        sut.DeleteTodo(1);
    }

}