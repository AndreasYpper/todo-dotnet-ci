
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
}