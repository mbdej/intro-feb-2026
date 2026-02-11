using Microsoft.AspNetCore.Mvc;

namespace TodoList.Api.Controllers;

public class TodosController : ControllerBase
{
    // when they a get request /todos
    [HttpGet("/todos")]
    public async Task<ActionResult> GetAllTodos()
    {
        
        return Ok(new List<string> { "clean the garage", "take out the trash" });
    }
}
