using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Commands
{
    public record DeleteBulkClassSubjectCommand(List<Guid> subjectIds): IRequest<bool>;
}