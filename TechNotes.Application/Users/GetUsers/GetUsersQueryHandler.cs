using System;
using MediatR;
using TechNotes.Domain.User;

namespace TechNotes.Application.Users.GetUsers;

public class GetUsersQueryHandler(
    IUserRepository _userRepository,
    IUserService _userService
) : IRequestHandler<GetUsersQuery, Result<List<UserResponse>>>
{
    public async Task<Result<List<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        if (!await _userService.IsCurrentUserInRoleAsync("Admin"))
        {
            return Result.Fail<List<UserResponse>>("No esta autorizado para ver todos los usuarios");
        }

        var users = await _userRepository.GetALLUsersAsync();
        var response = new List<UserResponse>();
        foreach (var user in users)
        {
            var roles = await _userService.GetUserRolesAsync(user.Id);
            var userResponse = user.Adapt<UserResponse>();
            userResponse.Roles = string.Join(", ", roles);
            response.Add(userResponse);
        }

        return response;
    }
}
