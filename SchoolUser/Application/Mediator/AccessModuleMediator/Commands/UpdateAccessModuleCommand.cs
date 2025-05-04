using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Commands
{
    public record UpdateAccessModuleCommand(AccessModule accessModule) : IRequest<AccessModule?>;
}