using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands
{
    public record AddBulkClassSubjectStudentCommand(List<ClassSubjectStudent> classSubjectStudents) : IRequest<bool>;
}