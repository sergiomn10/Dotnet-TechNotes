using System;
using System.Net.Http.Json;
using TechNotes.Application.Notes;

namespace TechNotes.Client.Features.Notes;

public class NotesOverviewServiceClient(
    HttpClient _http
) : INotesOverviewService
{
    public async Task<List<NoteResponse>?> GetNoteByCurrentUserAsync()
    {
        return await _http.GetFromJsonAsync<List<NoteResponse>>("/api/notes");
    }

    public async Task<NoteResponse?> TogglePublishNoteAsync(int noteId)
    {
        var result = await _http.PatchAsync($"api/notes/{noteId}", null);
        if (result is not null && result.Content is not null)
        {
            return await result.Content.ReadFromJsonAsync<NoteResponse>();
        }
        return null;
    }
}
