using System;
using TechNotes.Application.Users;

namespace TechNotes.Application.Notes.TogglePublishNote;

public class TogglePublishNoteCommandHandler(
    INoteRepository _noteRepository,
    IUserService _userService
) : ICommandHandler<TogglePublishNoteCommand, NoteResponse>
{
    public async Task<Result<NoteResponse>> Handle(TogglePublishNoteCommand request, CancellationToken cancellationToken)
    {
        var currentUserCanEdit = await _userService.CurrentUserCanEditNoteAsync(request.NoteId);
        if (!currentUserCanEdit)
        {
            return Result.Fail<NoteResponse>("No tiene permiso para editar esta nota");
        }
        var note = await _noteRepository.GetNoteByIdAsync(request.NoteId);
        if (note is null)
        {
            return Result.Fail<NoteResponse>("Nota no encontrada");

        }
        note.IsPublished = !note.IsPublished;
        note.UpdatedAt = DateTime.Now;
        if (note.IsPublished)
        {
            note.PublishedAt = DateTime.Now;
        }
        var updateNote = await _noteRepository.UpdateNoteAsync(note);

        return updateNote is null ? Result.Fail<NoteResponse>("No  se pudo actualizar la nota.") : updateNote.Adapt<NoteResponse>();

    }
}
