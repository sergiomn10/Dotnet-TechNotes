using System;

namespace TechNotes.Application.Users.AddRoleToUser;

public class AddRoleToUserCommandHandler(
    IUserService _userService
) : ICommandHandler<AddRoleToUserCommand>
{
    public async Task<Result> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _userService.AddUserRolesAsync(request.UserId, request.RoleName);
            return Result.Ok();
        }
        catch (System.Exception ex)
        {
            return Result.Fail($"Error al adicionar un rol al usuario. {ex.Message}");
        }
    }
}
