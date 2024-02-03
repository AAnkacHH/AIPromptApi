using System.ComponentModel.DataAnnotations;

namespace PromptAPI.Model.Request;

public class CreateUserRequest
{
    [Required]
    [MaxLength(255)]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [MaxLength(255)]
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
}
