using System;
using Mapster;
using MediatR;
using TechNotes.Domain.Notes;

namespace TechNotes.Application.Notes.CreateNote;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, NoteResponse>
{
    private readonly INoteRepository _noteRepository;
    public CreateNoteCommandHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    public async Task<NoteResponse> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
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
