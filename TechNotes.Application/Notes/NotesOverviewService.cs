using System;
using MediatR;
using TechNotes.Application.Notes.GetNotesByCurrentUser;
using TechNotes.Application.Notes.TogglePublishNote;

namespace TechNotes.Application.Notes;

public class NotesOverviewService(
    ISender _sender
) : INotesOverviewService
{
    public async Task<List<NoteResponse>?> GetNoteByCurrentUserAsync()
    {
        var result = await _sender.Send(new GetNotesByCurrentUserQuery());
        return result;
    }

    public async Task<NoteResponse?> TogglePublishNoteAsync(int noteId)
    {
        var result = await _sender.Send(new TogglePublishNoteCommand
        {
            NoteId = noteId
        });
        return result;
    }
}
