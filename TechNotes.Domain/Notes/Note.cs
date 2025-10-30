using System;
using TechNotes.Domain.Abtractions;

namespace TechNotes.Domain.Notes;

public class Note : Entity // se hereda la clase Entity para acceder a las propiedades comunes
{
    public required string Title { get; set; }
    public string? Content { get; set; }
    public DateTime? PublishedAt { get; set; }
    public bool IsPublished { get; set; } = false;
    public string? UserId { get; set; }

}
