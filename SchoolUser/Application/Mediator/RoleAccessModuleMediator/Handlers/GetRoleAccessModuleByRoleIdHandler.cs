using MediatR;
using SchoolUser.Application.Mediator.RoleAccessModuleMediator.Queries;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.RoleAccessModuleMediator.Handlers
{
    public class GetRoleAccessModuleByRoleIdHandler : IRequestHandler<GetRoleAccessModuleByRoleIdQuery, IEnumerable<RoleAccessModule>?>
    {
        private readonly IRoleAccessModuleRepository _roleAccessModuleRepository;

        public GetRoleAccessModuleByRoleIdHandler(IRoleAccessModuleRepository roleAccessModuleRepository)
        {
            _roleAccessModuleRepository = roleAccessModuleRepository;
        }

        public async Task<IEnumerable<RoleAccessModule>?> Handle(GetRoleAccessModuleByRoleIdQuery request, CancellationToken cancellationToken)
        {
            return await _roleAccessModuleRepository.GetByRoleIdAsync(request.roleId);
        }
    }
}