using MediatR;
using SchoolUser.Application.Mediator.RoleAccessModuleMediator.Queries;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.RoleAccessModuleMediator.Handlers
{
    public class GetRoleAccessModuleByAccessModuleIdHandler : IRequestHandler<GetRoleAccessModuleByAccessModuleIdQuery, IEnumerable<RoleAccessModule>?>
    {
        private readonly IRoleAccessModuleRepository _roleAccessModuleRepository;

        public GetRoleAccessModuleByAccessModuleIdHandler(IRoleAccessModuleRepository roleAccessModuleRepository)
        {
            _roleAccessModuleRepository = roleAccessModuleRepository;
        }

        public async Task<IEnumerable<RoleAccessModule>?> Handle(GetRoleAccessModuleByAccessModuleIdQuery request, CancellationToken cancellationToken)
        {
            return await _roleAccessModuleRepository.GetByAccessModuleIdAsync(request.accessModuleId);
        }
    }
}