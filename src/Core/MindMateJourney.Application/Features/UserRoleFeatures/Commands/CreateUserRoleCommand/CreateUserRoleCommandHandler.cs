﻿using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.UserRoleFeatures.Commands.CreateUserRoleCommand;


public sealed class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, MessageResponse>
{
    private readonly IUserRoleService _userRoleService;

    public CreateUserRoleCommandHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public async Task<MessageResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _userRoleService.CreateAsync(request, cancellationToken);
        return new("Kullanıcıya rol başarıyla atandı!", true);
    }
}