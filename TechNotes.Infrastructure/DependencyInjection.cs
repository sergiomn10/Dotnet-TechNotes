using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechNotes.Domain.Notes;
using TechNotes.Infrastructure.Repositories;

namespace TechNotes.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("TechNotes.Infrastructure") //aqui se indica en que ensamblado se aplicaran los cambios a DB
            )
        );

        services.AddScoped<INoteRepository, NoteRepository>();
        return services;
    }
}
