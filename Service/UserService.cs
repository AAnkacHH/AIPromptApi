using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromptAPI.Model.Entity;
using PromptAPI.Model.Request;
using PromptAPI.Model.Response;
using PromptAPI.Service.Database;
using PromptAPI.Utils;

namespace PromptAPI.Service;

public class UserService(
    PromptDbContext context, 
    IMapper mapper,
    IPasswordHasher hasher
    ) : IUserService
{
    // Create
    public async Task<UserResponse> CreateUserAsync(CreateUserRequest request)
    {
        var user = mapper.Map<User>(request);
        user.PasswordHash = hasher.HashPassword(request.Password);
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return mapper.Map<UserResponse>(user);
    }

    // Read
    public async Task<UserResponse> GetUserByIdAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        return mapper.Map<UserResponse>(user);
    }
    
    public async Task<User?> FindUserByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }
    
    public async Task<User?> FindUserByUsername(string username)
    {
        return context.Users.FirstOrDefault(user => user.Username == username);
    }

    public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
    {
        return await mapper.ProjectTo<UserResponse>(context.Users.AsQueryable()).ToListAsync();
    }

    // Update
    public async Task UpdateUserAsync(User user, UpdateUserRequest request)
    {
        mapper.Map(request, user);
        user.CreatedAt = DateTime.UtcNow.ToUniversalTime();
        user.LastLogin = DateTime.UtcNow.ToUniversalTime();
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    // Delete
    public async Task DeleteUserAsync(User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}
