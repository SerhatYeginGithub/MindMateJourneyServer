using AutoMapper;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.DeleteCategoryCommand;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.UpdateCategoryCommand;
using MindMateJourney.Application.Features.CategoryFeatures.Queries.GetAllCategoriesQuery;
using MindMateJourney.Application.Features.CategoryFeatures.Queries.GetCategoryById;
using MindMateJourney.Application.Repositories;
using MindMateJourney.Application.Services;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Services;

public sealed class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IContentRepository _contentRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork, IContentRepository contentRepository)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _contentRepository = contentRepository;
    }

    public async Task CreateAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var isCategoryExists = await IsCategoryExists(request.Name, cancellationToken);
        if (isCategoryExists)
        {
            throw new Exception("Category already exists.");
        }

        Category category = _mapper.Map<Category>(request);
        _categoryRepository.Add(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryRepository.DeleteByExpressionAsync(x => x.Id == request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<GetAllCategoriesDto>> GetAllAsync(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        IList<Category> categories = await _categoryRepository.GetAll()
            .OrderBy(c => c.Name)
            .ToListAsync(cancellationToken);
        var result = _mapper.Map<IList<GetAllCategoriesDto>>(categories);
        return result;
    }

    public async Task<GetCategoryByIdDto> GetByIdAsync(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetByExpressionAsync(x => x.Id == request.Id, cancellationToken);

        if (category == null)
        {
            throw new Exception("Category not found.");
        }

        List<Content> contents = await _contentRepository
       .Where(x => x.CategoryId == request.Id)
       .OrderByDescending(x => x.CreatedAt)
       .Skip((request.PageNumber - 1) * request.PageSize)
       .Take(request.PageSize)
       .ToListAsync(cancellationToken);

        return new GetCategoryByIdDto(
            category.Id,
            category.Name,
            _mapper.Map<List<ContentDto>>(contents));
    }

    public async Task UpdateAsync(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var isCategoryExists = await IsCategoryExists(request.Name, cancellationToken);
        if (isCategoryExists)
        {
            throw new Exception("Category already exists.");
        }

        Category category = _mapper.Map<Category>(request);
        _categoryRepository.Update(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task<bool> IsCategoryExists(string name, CancellationToken cancellationToken)
    {
        bool result = await _categoryRepository.AnyAsync(x => x.Name == name, cancellationToken);
        return result;
    }
}
