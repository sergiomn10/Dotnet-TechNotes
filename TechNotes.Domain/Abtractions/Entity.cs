using System;

namespace TechNotes.Domain.Abtractions;

// clase abstaracta para evitar propiedades repetidas
public abstract class Entity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
}
