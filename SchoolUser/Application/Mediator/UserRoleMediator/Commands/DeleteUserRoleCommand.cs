using MediatR;

namespace SchoolUser.Application.Mediator.UserRoleMediator.Commands
{
    public record DeleteUserRoleCommand(Guid id) : IRequest<bool>;
}