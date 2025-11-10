using TechNotes.Application.Users;
using TechNotes.Domain.User;

namespace TechNotes.Application.Notes.GetNotes;

public class GetNotesQueryHandler(
    INoteRepository _noteRepository,
    IUserRepository _userRepository,
    IUserService _userService
    ) : IQueryHandler<GetNotesQuery, List<NoteResponse>>
{
    // private readonly INoteRepository _noteRepository;

    // public GetNotesQueryHandler(INoteRepository noteRepository)
    // {
    //     _noteRepository = noteRepository;
    // }
    public async Task<Result<List<NoteResponse>>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await _noteRepository.GetAllNotesAsync();
        var response = new List<NoteResponse>();
        foreach (var note in notes)
        {
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

            response.Add(noteResponse);
        }
        // return notes.Adapt<List<NoteResponse>>(); // con ayuda de la libreria Mapster se hace el mapeo automatico al modelo deseado.
        return response.OrderByDescending(note => note.PublishedAt).ToList();
    }
}
