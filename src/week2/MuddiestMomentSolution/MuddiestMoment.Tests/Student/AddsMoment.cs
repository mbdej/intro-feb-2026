

using Alba;
using MuddiestMoment.Api.Student.Endpoints;
using System.Reflection;

namespace MuddiestMoment.Tests.Student;

public class AddsMoment
{
    [Fact]
    public async Task CanAddMoment()
    {
        var host = await AlbaHost.For<Program>();

        // scenario
        // start up the api
        // make the request with some data to /student/moments
        // that status code should be a 200
        // we should also get some stuff back
        // part 2 later

        var itemToSend = new StudentMomentCreateModel
        {
            Title = "Containers",
            Description = "Tell me about volumes"
        };

        var response = await host.Scenario(api =>
        {
            // Fluent interface - a "Domain Specific Langague"
            api.Post.Json(itemToSend).ToUrl("/student/moments");
            api.StatusCodeShouldBeOk();
        });

    }
}
