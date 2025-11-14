using System;

namespace TechNotes.Application.Users.GetUserRoles;

public class GetUserRolesQueryHandler(
    IUserService _userService
) : IQueryHandler<GetUserRolesQuery, List<string>>
{
    public async Task<Result<List<string>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _userService.GetUserRolesAsync(request.UserId);
        return Result.Ok(roles);
    }
}
