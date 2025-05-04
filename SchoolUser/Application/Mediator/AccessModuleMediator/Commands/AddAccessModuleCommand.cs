using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Commands
{
    public record AddAccessModuleCommand(AccessModule accessModule): IRequest<AccessModule>;
}