using MediatR;
using SchoolUser.Application.Mediator.RoleAccessModuleMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;

namespace SchoolUser.Application.Mediator.RoleAccessModuleMediator.Handlers
{
    public class DeleteRoleAccessModuleHandler : IRequestHandler<DeleteRoleAccessModuleCommand, bool>
    {
        private readonly IRoleAccessModuleRepository _roleAccessModuleRepository;

        public DeleteRoleAccessModuleHandler(IRoleAccessModuleRepository roleAccessModuleRepository)
        {
            _roleAccessModuleRepository = roleAccessModuleRepository;
        }

        public async Task<bool> Handle(DeleteRoleAccessModuleCommand request, CancellationToken cancellationToken)
        {
            return await _roleAccessModuleRepository.DeleteAsync(request.id);
        }
    }
}