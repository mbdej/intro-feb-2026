using System.ComponentModel.DataAnnotations;

namespace MuddiestMoment.Api.Student.Endpoints;

/* POST https://localhost:1337/student/moments 
Content-Type: application/json
 
 
{
    "title": "HTTP",
    "description": "More On Resources, plz."
}
*/

public record StudentMomentCreateModel
{
    [MinLength(3), MaxLength(50)]
    public required string Title { get; set; } = string.Empty;
    [MaxLength(150)]
    public string Description { get; set; } = string.Empty;
}
