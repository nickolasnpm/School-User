using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries
{
    public record GetClassSubjectTeacherListByTeacherIdQuery(Guid teacherId) : IRequest<IEnumerable<ClassSubjectTeacher>?>;
}