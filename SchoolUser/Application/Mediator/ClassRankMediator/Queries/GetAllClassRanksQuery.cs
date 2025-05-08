using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Queries
{
    public record GetAllClassRanksQuery(bool? isActive) : IRequest<IEnumerable<ClassRank>?>;
}