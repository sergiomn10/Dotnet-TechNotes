using System;
using TechNotes.Application.Users;

namespace TechNotes.Application.Notes.GetNotesByCurrentUser;

public class GetNotesByCurrentUserQueryHandler(
    INoteRepository _noteRepository,
    IUserService _userService
) : IQueryHandler<GetNotesByCurrentUserQuery, List<NoteResponse>>
{
    public async Task<Result<List<NoteResponse>>> Handle(GetNotesByCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var userId = await _userService.GetCurrentUserIdAsync();
        var notes = await _noteRepository.GetNotesByUserAsync(userId);
        var result = notes.Adapt<List<NoteResponse>>();
        return result.OrderByDescending(note => note.PublishedAt).ToList();
    }
}
