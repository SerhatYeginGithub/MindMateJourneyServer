using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Features.ContentFeatures.Commands.CreateContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Commands.DeleteContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Commands.UpdateContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Queries.GetAllContentsQuery;
using MindMateJourney.Application.Features.ContentFeatures.Queries.GetContentByIdQuery;

namespace MindMateJourney.Application.Services;

public interface IContentService 
{
    Task CreateAsync(CreateContentCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateContentCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteContentCommand request, CancellationToken cancellationToken);
    Task<List<ContentDto>> GetAllAsync(GetAllContentQuery request, CancellationToken cancellationToken);
    Task<ContentDto> GetByIdAsync(GetContentByIdQuery request, CancellationToken cancellationToken);

}
