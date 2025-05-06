using AutoMapper;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            
        }
    }

}
