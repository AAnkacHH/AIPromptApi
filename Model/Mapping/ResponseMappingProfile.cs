using AutoMapper;
using PromptAPI.Model.Entity;
using PromptAPI.Model.Response;

namespace PromptAPI.Model.Mapping;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile()
    {
        CreateMap<Category, CategoryResponse>();
        CreateMap<User, UserResponse>();
        CreateMap<User, UserDetailResponse>();
        CreateMap<Prompt, PromptResponse>();
        CreateMap<Prompt, PromptResponseDetail>();
    }
}
