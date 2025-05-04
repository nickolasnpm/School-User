

using MediatR;
using SchoolUser.Application.Mediator.RoleAccessModuleMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.RoleAccessModuleMediator.Handlers
{
    public class AddRoleAccessModuleHandler : IRequestHandler<AddRoleAccessModuleCommand, RoleAccessModule?>
    {
        private readonly IRoleAccessModuleRepository _roleAccessModuleRepository;

        public AddRoleAccessModuleHandler(IRoleAccessModuleRepository roleAccessModuleRepository)
        {
            _roleAccessModuleRepository = roleAccessModuleRepository;
        }

        public async Task<RoleAccessModule?> Handle(AddRoleAccessModuleCommand request, CancellationToken cancellationToken)
        {
            return await _roleAccessModuleRepository.CreateAsync(request.RoleAccessModule);
        }
    }
}