using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.RoleAccessModuleMediator.Queries
{
    public record GetRoleAccessModuleByRoleIdQuery(Guid roleId) : IRequest<IEnumerable<RoleAccessModule>?>;
}