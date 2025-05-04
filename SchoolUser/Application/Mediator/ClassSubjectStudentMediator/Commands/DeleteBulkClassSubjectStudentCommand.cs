using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands
{
    public record DeleteBulkClassSubjectStudentCommand(List<Guid> classSubjectIds) : IRequest<bool>;
}