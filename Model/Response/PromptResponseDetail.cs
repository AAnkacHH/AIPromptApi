namespace PromptAPI.Model.Response;

public class PromptResponseDetail : PromptResponse
{
    public UserResponse Author { get; set; }
    public CategoryResponse Category { get; set; }
}