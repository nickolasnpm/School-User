using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries
{
    public record GetClassSubjectTeacherListByClassSubjectIdQuery(Guid classSubjectId) : IRequest<IEnumerable<ClassSubjectTeacher>?>;
}