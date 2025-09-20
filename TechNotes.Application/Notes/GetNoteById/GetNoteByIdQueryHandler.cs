namespace TechNotes.Application.Notes.GetNoteById;

public class GetNoteByIdQueryHandler : IQueryHandler<GetNoteByIdQuery, NoteResponse?>
{
    private readonly INoteRepository _noteRepository;

    public GetNoteByIdQueryHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    public async Task<Result<NoteResponse?>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _noteRepository.GetNoteByIdAsync(request.Id);

        return result is null ? Result.Fail<NoteResponse?>("Nota no encontrada") : result.Adapt<NoteResponse>();
    }
}
