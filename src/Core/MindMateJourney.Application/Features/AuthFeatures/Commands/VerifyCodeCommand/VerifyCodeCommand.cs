using System.Globalization;
using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.AuthFeatures.Commands.VerifyCodeCommand;

public sealed record VerifyCodeCommand(string Email, string Code) : IRequest<MessageResponse>;
