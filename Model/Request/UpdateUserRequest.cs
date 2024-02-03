using System.ComponentModel.DataAnnotations;

namespace PromptAPI.Model.Request;

public class UpdateUserRequest
{
    [MaxLength(255)]
    public string Username { get; set; }
    
    [MaxLength(255)]
    public string Email { get; set; }
    
    public bool? IsActive { get; set; }
    public bool? IsAdmin { get; set; }
}
