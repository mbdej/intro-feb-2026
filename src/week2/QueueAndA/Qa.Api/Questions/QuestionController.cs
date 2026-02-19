using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Qa.Api.Questions;

[ApiController]
public class QuestionController(IDocumentSession session) : ControllerBase
{
    


    // /questions
    [HttpGet("/questions")]
    public async Task<ActionResult<IList<QuestionListItem>>> GetAllQuestions()
    {
        var questions = await session.Query<QuestionListItem>().ToListAsync();

        return Ok(questions); // for right now
    }
}



public record QuestionListItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public List<SubmittedAnswer>? SubmittedAnswers { get; set; }
}

public record SubmittedAnswer
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
}