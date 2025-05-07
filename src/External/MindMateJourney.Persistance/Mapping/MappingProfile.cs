using AutoMapper;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.UpdateCategoryCommand;
using MindMateJourney.Application.Features.ContentFeatures.Commands.CreateContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Commands.UpdateContentCommand;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        CreateMap<Category, GetAllCategoriesDto>().ReverseMap();
        CreateMap<Category, GetCategoryByIdDto>().ReverseMap();
        CreateMap<Content, ContentDto>().ReverseMap();
        CreateMap<Content, CreateContentCommand>().ReverseMap();
        CreateMap<UpdateContentCommand, Content>().ReverseMap();
    }
}
