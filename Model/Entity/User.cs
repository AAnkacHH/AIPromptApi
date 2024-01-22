using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromptAPI.Model.Entity;

[Table("users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    [MaxLength(255)]
    public string Email { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastLogin { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsAdmin { get; set; } = false;
    
    public virtual ICollection<Prompt> Prompts { get; set; }
}