using System;
using Microsoft.Extensions.DependencyInjection;
using TechNotes.Application.Notes;

namespace TechNotes.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly); // se agrega esta inyeccion para poder utilizar el patron mediador con CQRS
        });
        // services.AddScoped<INoteService, NoteService>(); // se elimino este servicio porque se sustituye con el patron mediador
        return services;
    }
}
