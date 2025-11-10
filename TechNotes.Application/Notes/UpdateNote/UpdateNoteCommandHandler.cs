using TechNotes.Application.Users;

namespace TechNotes.Application.Notes.UpdateNote;

public class UpdateNoteCommandHandler(INoteRepository _noteRepository,
    IUserService _userService
) : ICommandHandler<UpdateNoteCommand, NoteResponse?>
{
    public async Task<Result<NoteResponse?>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var noteToUpdate = request.Adapt<Note>();
        var currentUserCanEdit = await _userService.CurrentUserCanEditNoteAsync(noteToUpdate.Id);
        if (!currentUserCanEdit)
        {
            return Result.Fail<NoteResponse?>("No tiene permiso para editar esta nota");
        }
        var updateNote = await _noteRepository.UpdateNoteAsync(noteToUpdate);

        return updateNote is null ? Result.Fail<NoteResponse?>("Nota no encontrada o no se pudo actualizar la nota.") : updateNote.Adapt<NoteResponse>();
    }
}
