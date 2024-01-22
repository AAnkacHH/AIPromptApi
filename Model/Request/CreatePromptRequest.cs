namespace PromptAPI.Model.Request;

public class CreatePromptRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Prompt { get; set; }
    public bool Usefull { get; set; }
    public int? AuthorId { get; set; }
    public int? CategoryId { get; set; }
    public string Language { get; set; }
    public decimal? Rating { get; set; }
    public string Source { get; set; }
    public string Status { get; set; }
}
