using System;

namespace TechNotes.Application.Notes;

// Se usa record para mejorar el rendimiento
public record struct NoteResponse
(
    int Id,
    string Title,
    string? Content,
    DateTime CreatedAt,
    DateTime PublishedAt,
    bool IsPublished,
    string? UserName

);
