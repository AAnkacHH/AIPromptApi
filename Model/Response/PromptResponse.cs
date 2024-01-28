namespace PromptAPI.Model.Response;

public class PromptResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PromptText { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public bool Usefull { get; set; }
    public int? AuthorId { get; set; }
    public int? CategoryId { get; set; }
    public string Language { get; set; }
    public decimal? Rating { get; set; }
    public int AccessCount { get; set; }
    public string Source { get; set; }
    public string Status { get; set; }
    public int? Version { get; set; }
}