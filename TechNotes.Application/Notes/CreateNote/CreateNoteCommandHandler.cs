using TechNotes.Application.Exceptions;
using TechNotes.Application.Users;

namespace TechNotes.Application.Notes.CreateNote;

public class CreateNoteCommandHandler(
    INoteRepository _noteRepository,
    IUserService _userService
) : ICommandHandler<CreateNoteCommand, NoteResponse>
{

    public async Task<Result<NoteResponse>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        // var newNOte = new Note
        // {
        //     Title = request.Title,
        //     Content = request.Content,
        //     PublishedAt = request.PublishedAt,
        //     IsPublished = request.IsPublished
        // };
        try
        {
            var newNote = request.Adapt<Note>();
            var userId = await _userService.GetCurrentUserIdAsync();
            if (userId is null)
            {
                return FailNoteCreate();
            }
            var isCurrentUserCanCreate = await _userService.CurrentUserCanCreateNoteAsync();
            if (isCurrentUserCanCreate == false) return FailNoteCreate();
            newNote.UserId = userId;
            var note = await _noteRepository.CreateNoteAsync(newNote);
            return note.Adapt<NoteResponse>();
        }
        catch (UserNotAuthorizedException)
        {
            return FailNoteCreate();
        }
    }

    private static Result<NoteResponse> FailNoteCreate()
    {
        return Result.Fail<NoteResponse>("El usuario no esta autorizado para crear una nota");
    }
}
