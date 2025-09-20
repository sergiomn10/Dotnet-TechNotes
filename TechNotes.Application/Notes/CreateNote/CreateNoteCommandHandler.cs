namespace TechNotes.Application.Notes.CreateNote;

public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand, NoteResponse>
{
    private readonly INoteRepository _noteRepository;
    public CreateNoteCommandHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    public async Task<Result<NoteResponse>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        // var newNOte = new Note
        // {
        //     Title = request.Title,
        //     Content = request.Content,
        //     PublishedAt = request.PublishedAt,
        //     IsPublished = request.IsPublished
        // };

        var newNote = request.Adapt<Note>();

        var note = await _noteRepository.CreateNoteAsync(newNote);
        return note.Adapt<NoteResponse>();
    }
}
