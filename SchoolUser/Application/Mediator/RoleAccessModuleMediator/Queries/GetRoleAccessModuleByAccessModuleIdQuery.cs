using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.RoleAccessModuleMediator.Queries
{
    public record GetRoleAccessModuleByAccessModuleIdQuery(Guid accessModuleId) : IRequest<IEnumerable<RoleAccessModule>?>;
}