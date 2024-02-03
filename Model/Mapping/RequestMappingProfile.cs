using AutoMapper;
using PromptAPI.Model.Entity;
using PromptAPI.Model.Request;

namespace PromptAPI.Model.Mapping;

public class RequestMappingProfile : Profile
{
    public RequestMappingProfile()
    {
        CreateMap<CreatePromptRequest, Prompt>()
            .ForMember(dest => dest.PromptText, opt => opt.MapFrom(src => src.Prompt))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.ModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.AccessCount, opt => opt.MapFrom(src => 0)); // Встановити за замовчуванням 0
        CreateMap<CreateCategoryRequest, Category>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
    }
}
