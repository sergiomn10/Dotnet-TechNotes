namespace TechNotes.Application.Notes.GetNotes;

// se puede utilizar de esta manera IRequest<Result<List<NoteResponse>>> pero se hara con conversion implicita, en la clase Result 
public class GetNotesQuery : IQuery<List<NoteResponse>>
{

}
