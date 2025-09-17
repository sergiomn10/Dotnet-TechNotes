using System;
using Mapster;
using MediatR;
using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes.GetNoteById;

public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, NoteResponse?>
{
    private readonly INoteRepository _noteRepository;

    public GetNoteByIdQueryHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    public async Task<NoteResponse?> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _noteRepository.GetNoteByIdAsync(request.Id);

        return result is null ? null : result.Adapt<NoteResponse>();
    }
}
