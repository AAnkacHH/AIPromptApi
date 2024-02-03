using PromptAPI.Model.Entity;
using PromptAPI.Model.Request;
using PromptAPI.Model.Response;

namespace PromptAPI.Service;

public interface IUserService
{
    Task<UserResponse> CreateUserAsync(CreateUserRequest request);
    Task<UserResponse> GetUserByIdAsync(int id);
    Task<IEnumerable<UserResponse>> GetAllUsersAsync();
    Task UpdateUserAsync(User user, UpdateUserRequest request);
    Task DeleteUserAsync(User user);

    Task<User?> FindUserByIdAsync(int id);
}
