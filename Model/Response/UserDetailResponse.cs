namespace PromptAPI.Model.Response;

public class UserDetailResponse : UserResponse
{
    public ICollection<PromptResponse> Prompts { get; set; }
}