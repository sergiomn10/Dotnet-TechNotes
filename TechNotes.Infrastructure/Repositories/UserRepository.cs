using System;
using Microsoft.AspNetCore.Identity;
using TechNotes.Domain.User;
using TechNotes.Infrastructure.Authentication;

namespace TechNotes.Infrastructure.Repositories;

public class UserRepository(UserManager<User> _userManager) : IUserRepository
{
    public async Task<IUser?> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }
}
