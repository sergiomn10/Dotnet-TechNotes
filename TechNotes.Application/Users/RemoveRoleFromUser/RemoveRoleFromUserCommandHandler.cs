using System;

namespace TechNotes.Application.Users.RemoveRoleFromUser;

public class RemoveRoleFromUserCommandHandler(
    IUserService _userService
) : ICommandHandler<RemoveRoleFromUserCommand>
{
    public async Task<Result> Handle(RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _userService.RemoveRoleFromUserAsync(request.UserId, request.RoleName);
            return Result.Ok();
        }
        catch (System.Exception ex)
        {
            return Result.Fail($"Error al eliminar el rol del usuario {ex.Message}");
        }
    }
}
