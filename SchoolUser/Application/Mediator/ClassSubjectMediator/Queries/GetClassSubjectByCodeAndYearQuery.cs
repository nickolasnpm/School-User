using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Queries
{
    public record GetClassSubjectByCodeAndYearQuery(string code, int year) : IRequest<ClassSubject?>;
}