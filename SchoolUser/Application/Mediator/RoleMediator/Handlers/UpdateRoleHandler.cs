using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.RoleMediator.Commands;
using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.RoleMediator.Handlers;

public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, Role?>
{
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role?> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        return await _roleRepository.UpdateAsync(request.Role);
    }
}
