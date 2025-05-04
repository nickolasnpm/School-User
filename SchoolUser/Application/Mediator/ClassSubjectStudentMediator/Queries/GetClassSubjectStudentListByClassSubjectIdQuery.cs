using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries
{
    public record GetClassSubjectStudentListByClassSubjectIdQuery(Guid ClassSubjectId) : IRequest<IEnumerable<ClassSubjectStudent>?>;
}