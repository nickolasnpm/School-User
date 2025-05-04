using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Commands
{
    public record AddBulkClassSubjectCommand(List<ClassSubject> classSubjects) : IRequest<bool>;
}