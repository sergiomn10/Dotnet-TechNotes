using System;
using MediatR;
using TechNotes.Domain.Abtractions;

namespace TechNotes.Application.Abstractions.RequestHandling;

public interface ICommandHandler<TCommand>: IRequestHandler<TCommand, Result>
where TCommand: ICommand
{

}



public interface ICommandHandler<TCommand, TResponse>: IRequestHandler<TCommand, Result<TResponse>>
where TCommand: ICommand<TResponse>
{

}
