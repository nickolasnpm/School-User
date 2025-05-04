using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands
{
    public record AddBulkClassSubjectTeacherCommand(List<ClassSubjectTeacher> ClassSubjectTeachers) : IRequest<bool>;
}