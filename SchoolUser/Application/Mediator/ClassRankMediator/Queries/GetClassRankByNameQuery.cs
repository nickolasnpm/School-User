using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Queries
{
    public record GetClassRankByNameQuery(string Name) : IRequest<ClassRank?>;
}