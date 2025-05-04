using MediatR;

namespace SchoolUser.Application.Mediator.RoleAccessModuleMediator.Commands
{
    public record DeleteRoleAccessModuleCommand(Guid id) : IRequest<bool>;
}