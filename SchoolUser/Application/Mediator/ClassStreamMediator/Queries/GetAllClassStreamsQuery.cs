using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Queries
{
    public record GetAllClassStreamsQuery(bool? isActive) : IRequest<IEnumerable<ClassStream>?>;
}