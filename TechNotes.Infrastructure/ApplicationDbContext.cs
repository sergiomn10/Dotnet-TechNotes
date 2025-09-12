using System;
using Microsoft.EntityFrameworkCore;
using TechNotes.Domain.Notes;

namespace TechNotes.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    
    public DbSet<Note> Notes { get; set; } // los nombres de estas propiedades son los que se llamaran en DB

}
