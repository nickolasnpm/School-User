using MediatR;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Commands
{
    public record DeleteAccessModuleCommand(Guid id) : IRequest<bool>;
}