using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Queries
{
    public record GetClassCategoryByCodeAndYearQuery(string code, int year) : IRequest<ClassCategory?>;
}