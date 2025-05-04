using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Queries
{
    public record GetClassRankByIdQuery(Guid id) : IRequest<ClassRank?>;
}