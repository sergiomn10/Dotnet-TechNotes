using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechNotes.Domain.User;
using TechNotes.Infrastructure.Users;

namespace TechNotes.Infrastructure.Repositories;

public class UserRepository(UserManager<User> _userManager) : IUserRepository
{
    public async Task<List<IUser>> GetALLUsersAsync()
    {
        return await _userManager.Users.Select(user => (IUser)user).ToListAsync();
    }

    public async Task<IUser?> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }
}
