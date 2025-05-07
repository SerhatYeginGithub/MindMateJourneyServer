using MindMateJourney.Application.Features.ContentFeatures.Commands.CreateContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Commands.DeleteContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Commands.UpdateContentCommand;

namespace MindMateJourney.Application.Services;

public interface IContentService 
{
    Task CreateAsync(CreateContentCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateContentCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteContentCommand request, CancellationToken cancellationToken);
}
