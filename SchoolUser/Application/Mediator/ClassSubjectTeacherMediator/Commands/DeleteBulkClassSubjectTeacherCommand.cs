using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands
{
    public record DeleteBulkClassSubjectTeacherCommand(List<Guid> classSubjectIds) : IRequest<bool>;
}