using AutoMapper;
using GenericRepository;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand;
using MindMateJourney.Application.Repositories;
using MindMateJourney.Application.Services;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Services;

public sealed class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = _mapper.Map<Category>(request);
        _categoryRepository.Add(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
