using TechNotes.Application.Users;
using TechNotes.Domain.User;

namespace TechNotes.Application.Notes.GetNoteById;

public class GetNoteByIdQueryHandler(
    INoteRepository _noteRepository,
    IUserRepository _userRepository,
    IUserService _userService
    ) : IQueryHandler<GetNoteByIdQuery, NoteResponse?>
{
    public async Task<Result<NoteResponse?>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
    {
        var note = await _noteRepository.GetNoteByIdAsync(request.Id);
        if (note is null)
        {
            return Result.Fail<NoteResponse?>("Nota no encontrada");
        }

        var noteResponse = note.Adapt<NoteResponse>();
        if (note.UserId != null)
        {
            var noteAuthor = await _userRepository.GetUserByIdAsync(note.UserId);
            noteResponse.UserName = noteAuthor?.UserName ?? "Desconocido";
            noteResponse.UserId = note.UserId;
            noteResponse.CanEdit = await _userService.CurrentUserCanEditNoteAsync(note.Id);
        }
        else
        {
            noteResponse.UserName = "Desconocido";
        }

        return noteResponse;
    }
}
