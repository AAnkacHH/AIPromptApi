using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromptAPI.Model.Entity;

[Table("prompt")]
public class Prompt
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public string PromptText { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ModifiedAt { get; set; }

    public bool Usefull { get; set; }
    
    [ForeignKey(nameof(AuthorId))]
    public virtual User Author { get; set; }
    public int? AuthorId { get; set; }

    // Навігаційна властивість для Category
    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; }
    public int? CategoryId { get; set; }

    [MaxLength(50)]
    public string Language { get; set; }

    public decimal? Rating { get; set; }

    public int AccessCount { get; set; } = 0;

    [MaxLength(255)]
    public string Source { get; set; }

    [MaxLength(50)]
    public string Status { get; set; }

    public int? Version { get; set; }
}
