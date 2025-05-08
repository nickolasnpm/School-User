using MediatR;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Commands
{
    public record DeleteClassRankCommand(Guid id) : IRequest<bool>;
}