using AutoMapper;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Features.ContentFeatures.Commands.CreateContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Commands.DeleteContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Commands.UpdateContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Queries.GetAllContentsQuery;
using MindMateJourney.Application.Features.ContentFeatures.Queries.GetContentByIdQuery;
using MindMateJourney.Application.Repositories;
using MindMateJourney.Application.Services;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Services;

public sealed class ContentService : IContentService
{
    private readonly IContentRepository _contentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ContentService(IContentRepository contentRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _contentRepository = contentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateContentCommand request, CancellationToken cancellationToken)
    {
        Content content = _mapper.Map<Content>(request);
        await _contentRepository.AddAsync(content, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DeleteContentCommand request, CancellationToken cancellationToken)
    {
        await _contentRepository.DeleteByExpressionAsync(x => x.Id == request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<ContentDto>> GetAllAsync(GetAllContentQuery request, CancellationToken cancellationToken)
    {
        List<Content> contents = await _contentRepository
            .GetAll()
            .OrderByDescending(x => x.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        return _mapper.Map<List<ContentDto>>(contents);
    }

    public async Task<ContentDto> GetByIdAsync(GetContentByIdQuery request, CancellationToken cancellationToken)
    {
      Content content = await _contentRepository.GetByExpressionAsync(x => x.Id == request.Id, cancellationToken);
        if (content == null)
        {
            throw new Exception("Content not found.");
        }
        return _mapper.Map<ContentDto>(content);
    }

    public async Task UpdateAsync(UpdateContentCommand request, CancellationToken cancellationToken)
    {
        Content content = _mapper.Map<Content>(request);
        _contentRepository.Update(content);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

}
