using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Queries
{
    public record GetAllAccessModulesQuery() : IRequest<IEnumerable<AccessModule>?>;
}