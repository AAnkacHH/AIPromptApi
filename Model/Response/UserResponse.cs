namespace PromptAPI.Model.Response;

public class UserResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLogin { get; set; }
    public bool IsActive { get; set; }
    public bool IsAdmin { get; set; }
}
