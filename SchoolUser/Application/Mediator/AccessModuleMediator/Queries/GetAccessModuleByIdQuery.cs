using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Queries
{
    public record GetAccessModuleByIdQuery(Guid id) : IRequest<AccessModule?>;
}