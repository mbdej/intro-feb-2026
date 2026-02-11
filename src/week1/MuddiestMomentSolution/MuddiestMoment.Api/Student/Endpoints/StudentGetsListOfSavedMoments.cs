using Marten;

namespace MuddiestMoment.Api.Student.Endpoints;

public static  class StudentGetsListOfSavedMoments
{
    public static async Task<IResult> GetAllMomentsForStudent(IDocumentSession session)
    {
        var moments = await session.Query<StudentMomentEntity>()
            .Where(m => m.AddedBy == "fake user" && m.IsAnswered == false) // this needs to be the ID of the person making this request.
            .ToListAsync();

        return TypedResults.Ok(moments);
    }
}
